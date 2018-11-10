using Assets.Scripts.GameInput;
using Assets.Scripts.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects {

    public class OvenHandler : MonoBehaviour
    {


        private bool playerEntered;
        private GameObject player;

        public Food heldFood;

        /// <summary>
        /// The timed cooldown for the oven.
        /// </summary>
        public TimedCooldown timer;

        public enum OvenState
        {
            Idle,
            Cooking,
            DoneCooking
        }

        public OvenState currentState;

        // Use this for initialization
        void Start()
        {

            currentState = OvenState.Idle;
        }

        // Update is called once per frame
        void Update()
        {

            if (playerEntered == true)
            {
                if (InputControls.APressed)
                {
                    CharacterController2D character = player.GetComponent<CharacterController2D>();

                    if (character.info.holdingFood && this.currentState== OvenState.Idle && character.info.heldFood.currentState!= Food.CookedState.Cooked)
                    {
                        timer = new TimedCooldown(100, character.info.heldFood.timeToCook, 0.1);
                        timer.start();

                        this.heldFood = Instantiate(character.info.heldFood); //REPLACE WITH SOME FOOD RECIPE FUNCTION LATER;
                        this.heldFood.gameObject.SetActive(false);
                        Destroy(character.info.heldFood.gameObject);
                        character.info.heldFood = null;
                        

                        this.currentState = OvenState.Cooking;
                    }
                    else if(character.info.holdingFood==false && this.currentState== OvenState.DoneCooking)
                    {
                        this.heldFood.gameObject.SetActive(true);
                        Food nom = Instantiate(this.heldFood);
                        nom.attatchToPlayer();
                        Destroy(this.heldFood.gameObject);
                        this.currentState = OvenState.Idle;
                    }
                }
            }
            if (timer != null)
            {
                if (timer.isReady() && this.heldFood!=null)
                {
                    Debug.Log("COOKING IS DONE!!! Cooked: "+this.heldFood.name);
                    this.currentState = OvenState.DoneCooking;
                    this.heldFood.cook();
                }
                else
                {
                    Debug.Log(timer.timeRemaining);
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
                this.player = collision.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerEntered = false;
                this.player = null;
            }

        }

    }
}
