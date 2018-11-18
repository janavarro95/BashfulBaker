using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts.GameInput;
using UnityEngine.SceneManagement;


namespace Assets.Scripts
{

    public class SelectOnInput : MonoBehaviour
    {
        public EventSystem eventSystem;
        public GameObject selectedObject;

        private bool buttonSelected;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InputControls.APressed && buttonSelected == false)
            {
                //need to find other way besides hard coding scene in
                SceneManager.LoadScene("Kitchen");
                //eventSystem.SetSelectedGameObject(selectedObject);                //code for when there are more menu buttons
                //buttonSelected = true;
            }

        }

        private void OnDisable()
        {
            buttonSelected = false;
        }
    }


}
