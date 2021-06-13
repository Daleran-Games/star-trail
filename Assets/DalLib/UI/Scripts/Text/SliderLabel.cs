using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace DaleranGames.UI
{
    public class SliderLabel : MonoBehaviour
    {

        public TextMeshProUGUI Text;
        public Slider Slider;
        public string Prefix;
        public string Suffix;
        public bool ShowMax = false;
        public string Divider = "/";

        private void OnEnable()
        {
            Slider.onValueChanged.AddListener(UpdateLabel);
            UpdateLabel(0f);
        }

        private void OnDisable()
        {
            Slider.onValueChanged.RemoveListener(UpdateLabel);
        }

        void UpdateLabel(float val)
        {
            Text.text = GetLabel();
        }

        public string GetLabel ()
        {
            if (ShowMax)
                return Prefix + Slider.value + Divider + Slider.maxValue + Suffix;
            else
                return Prefix + Slider.value  + Suffix;
        }
        
    }
}


