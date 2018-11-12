using Assets.Scripts.GameInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class BowlHandler:MonoBehaviour
    {

        private bool playerEntered;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (playerEntered == true)
            {
                if (InputControls.APressed)
                {
                    Debug.Log("MIX THE MIX");
                    //START BOWL MINIGAME...
                }
            }

        }




        private void OnTriggerStay2D(Collider2D collision)
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerEntered = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerEntered = false;
            }

        }
    }
}
