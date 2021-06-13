using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DaleranGames.UI
{
    public class ModalTest : MonoBehaviour
    {

        public ModalWindow testModal;


        // Use this for initialization
        void Start()
        {
            testModal.ShowDialog("This is a test", new ModalWindow.Choice("Ok",Confirmed), new ModalWindow.Choice("Cancel",Canceled));
        }

        void Confirmed()
        {
            Debug.Log("Confirmed!");
        }

        void Canceled()
        {
            Debug.Log("Canceled!");
        }

    }
}

