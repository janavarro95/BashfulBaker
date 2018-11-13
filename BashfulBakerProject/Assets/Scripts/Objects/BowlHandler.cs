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

        public enum BowlState
        {
            notMixing,
            currentlyMixing
        }

        public BowlState currentState;

        public GameObject player;


        // Use this for initialization
        void Start()
        {
            currentState = BowlState.notMixing;
        }

        // Update is called once per frame
        void Update()
        {

            if (playerEntered == true)
            {
                if (InputControls.APressed)
                {
                    //Player character = GameManager.getPlayer().GetComponent<Player>();
                    if(this.currentState == BowlState.notMixing)
                    {
                        Debug.Log("MIX THE MIX");
                        //START BOWL MINIGAME...
                        this.currentState = BowlState.currentlyMixing;
                        GameManager.getPlayer().GetComponent<CharacterController2D>().info.heldFood = GameManager.getGameManager().getFood("Cookie");

                    }
                    else
                    {
                        Debug.Log("YOU CAN'T MIX WHAT IS ALREADY MIXED");
                    }

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
