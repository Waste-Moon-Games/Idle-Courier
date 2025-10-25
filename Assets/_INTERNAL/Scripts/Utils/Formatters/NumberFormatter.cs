﻿using UnityEngine;

namespace Utils.Formatters
{
    public class NumberFormatter
    {
        private readonly string[] Suffixes = { "", "k", "M", "B", "T" };

        public string FormatNumber(float number)
        {
            if (number == 0)
                return "0";

            int magnitude = Mathf.FloorToInt(Mathf.Log10(Mathf.Abs(number)));
            int suffixIndex = Mathf.FloorToInt(magnitude / 3);

            suffixIndex = Mathf.Clamp(suffixIndex, 0, Suffixes.Length - 1);

            float value = number / Mathf.Pow(10, suffixIndex * 3);

            return value.ToString("0.#") + Suffixes[suffixIndex];
        }
    }
}