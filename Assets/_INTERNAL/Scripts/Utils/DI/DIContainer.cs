using System;
using System.Collections.Generic;

namespace Utils.DI
{
    public class DIContainer
    {
        private readonly DIContainer _parentContainer;
        private readonly Dictionary<(string, Type), DIEntry> _entriesMap = new();
        private readonly HashSet<(string, Type)> _resolutionsCache = new();

        public DIContainer(DIContainer parentContainer = null)
        {
            _parentContainer = parentContainer;
        }

        public DIEntry RegisterFactory<T>(Func<DIContainer, T> factroy)
        {
            return RegisterFactory(null, factroy);
        }

        public DIEntry RegisterFactory<T>(string tag, Func<DIContainer, T> factroy)
        {
            (string, Type) key = (tag, typeof(T));

            if (_entriesMap.ContainsKey(key))
                throw new Exception($"DI: Factory with tag: {key.Item1} and type {key.Item2.FullName} has already registred");

            DIEntry dIEntry = new DIEntry<T>(this, factroy);

            _entriesMap[key] = dIEntry;

            return dIEntry;
        }

        public void RegisterInstance<T>(T instance)
        {
            RegisterInstance(null, instance);
        }

        public void RegisterInstance<T>(string tag, T instance)
        {
            (string, Type) key = (tag, typeof(T));

            if (_entriesMap.ContainsKey(key))
                throw new Exception($"DI: Factory with tag {key.Item1} and type {key.Item2.FullName} has already registered");

            var diEntry = new DIEntry<T>(instance);

            _entriesMap[key] = diEntry;
        }

        public T Resolve<T>(string tag = null)
        {
            (string, Type) key = (tag, typeof(T));

            if (_resolutionsCache.Contains(key))
                throw new Exception($"Cyclic dependency for tag {tag} and type {key.Item2.FullName}");

            _resolutionsCache.Add(key);

            try
            {
                if (_entriesMap.TryGetValue(key, out var diEntry))
                {
                    return diEntry.Resolve<T>();
                }

                if (_parentContainer != null)
                    return _parentContainer.Resolve<T>(tag);
            }
            finally
            {
                _resolutionsCache.Remove(key);
            }

            throw new Exception($"Couldn't find dependency for tag {tag} and type {key.Item2.FullName}");
        }

        public void Dispose()
        {
            var entries = _entriesMap.Values;

            foreach (var entry in entries)
            {
                entry.Dispose();
            }
        }
    }
}