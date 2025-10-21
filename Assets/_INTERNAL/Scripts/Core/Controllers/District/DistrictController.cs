using Core.Instances;
using System;
using UI.Views;

namespace Core.Controllers
{
    public class DistrictController
    {
        private readonly int _cotrollerID;

        private readonly DistrictInstance _instance;
        private readonly DistrictView _districtView;

        public event Action<DistrictInstance> OnDistrictSelected;

        public DistrictController(DistrictInstance instance, DistrictView districtView, int controllerID)
        {
            _instance = instance;
            _districtView = districtView;
            _cotrollerID = controllerID;
        }

        public void Init()
        {
            _districtView.SetLogo(_instance.DData.Logo);
            _districtView.SetName(_instance.DData.Name);
            _districtView.SetCategory(_instance.DData.Category.ToString());
            _districtView.SetDescription(_instance.DData.Description);

            _districtView.OnDistrictSelected += HandleSelectedDistrict;
        }

        private void HandleSelectedDistrict()
        {
            OnDistrictSelected?.Invoke(_instance);
        }
    }
}