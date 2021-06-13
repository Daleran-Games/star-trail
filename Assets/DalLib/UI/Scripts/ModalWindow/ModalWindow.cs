using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace DaleranGames.UI
{
    public class ModalWindow : MonoBehaviour
    {
        public TextMeshProUGUI StoryText;

        public Button OptionA;
        public TextMeshProUGUI LabelA;
        public Button OptionB;
        public TextMeshProUGUI LabelB;
        public Button OptionC;
        public TextMeshProUGUI LabelC;
        public Button OptionD;
        public TextMeshProUGUI LabelD;

        private void Awake()
        {
            CloseWindow();
        }

        public void ShowDialog(string story,Choice choiceA)
        {
            SetUpWindow(story);
            SetUpOptionA(choiceA);
        }

        public void ShowDialog(string story, Choice choiceA, Choice choiceB)
        {
            SetUpWindow(story);
            SetUpOptionA(choiceA);
            SetUpOptionB(choiceB);
        }

        public void ShowDialog(string story, Choice choiceA, Choice choiceB, Choice choiceC)
        {
            SetUpWindow(story);
            SetUpOptionA(choiceA);
            SetUpOptionB(choiceB);
            SetUpOptionC(choiceC);
        }

        public void ShowDialog(string story, Choice choiceA, Choice choiceB, Choice choiceC, Choice choiceD)
        {
            SetUpWindow(story);
            SetUpOptionA(choiceA);
            SetUpOptionB(choiceB);
            SetUpOptionC(choiceC);
            SetUpOptionD(choiceD);
        }

        void SetUpWindow(string story)
        {
            CloseWindow();
            StoryText.text = story;
            gameObject.SetActive(true);
        }

        void SetUpOptionA(Choice choice)
        {
            OptionA.gameObject.SetActive(true);
            LabelA.text = choice.Label;
            OptionA.onClick.AddListener(CloseWindow);
            OptionA.onClick.AddListener(choice.Callback);
        }

        void SetUpOptionB(Choice choice)
        {
            OptionB.gameObject.SetActive(true);
            LabelB.text = choice.Label;
            OptionB.onClick.AddListener(CloseWindow);
            OptionB.onClick.AddListener(choice.Callback);
        }

        void SetUpOptionC(Choice choice)
        {
            OptionC.gameObject.SetActive(true);
            LabelC.text = choice.Label;
            OptionC.onClick.AddListener(CloseWindow);
            OptionC.onClick.AddListener(choice.Callback);
        }

        void SetUpOptionD(Choice choice)
        {
            OptionD.gameObject.SetActive(true);
            LabelD.text = choice.Label;
            OptionD.onClick.AddListener(CloseWindow);
            OptionD.onClick.AddListener(choice.Callback);
        }

        public void CloseWindow()
        {
            OptionA.onClick.RemoveAllListeners();
            OptionB.onClick.RemoveAllListeners();
            OptionC.onClick.RemoveAllListeners();
            OptionD.onClick.RemoveAllListeners();

            OptionA.gameObject.SetActive(false);
            OptionB.gameObject.SetActive(false);
            OptionC.gameObject.SetActive(false);
            OptionD.gameObject.SetActive(false);

            gameObject.SetActive(false);
        }


        public class Choice
        {
            public string Label;
            public UnityAction Callback;

            public Choice(string story, UnityAction callback)
            {
                Label = story;
                Callback = callback;
            }
        }
    }
}

