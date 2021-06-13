using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace DaleranGames.StarTrail
{
    public class ChoiceButtons : MonoBehaviour
    {
        [SerializeField]
        private List<Button> _buttons;

        [SerializeField]
        private List<Text> _labels;

        public void SetupButton(int button, string text, UnityAction listener)
        {
            _buttons[button].gameObject.SetActive(true);
            _buttons[button].onClick.AddListener(listener);
            _labels[button].text = text;
            _buttons[button].gameObject.name = text;
        }

        public void ResetButton(int button)
        {
            _buttons[button].onClick.RemoveAllListeners();
            _labels[button].text = "";
            _buttons[button].gameObject.name = "Choice-" + button;
            _buttons[button].gameObject.SetActive(false);
        }

        public void ResetAll()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                ResetButton(i);
            }
        }
    }
}