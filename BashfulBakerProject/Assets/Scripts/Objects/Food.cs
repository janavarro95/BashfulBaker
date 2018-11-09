using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class Food : Item
    {
        public double timeToCook;
        public List<Item> ingredients;

        public Sprite rawSprite;
        public Sprite cookedSprite;

        public enum CookedState
        {
            Raw,
            Cooked
        }

        public CookedState currentState;

        public void Start()
        {
            updateSprite();
        }

        public void updateSprite()
        {
            if (this.currentState == CookedState.Raw) {

                this.gameObject.GetComponent<SpriteRenderer>().sprite = rawSprite;
            }
            else if (this.currentState == CookedState.Cooked)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cookedSprite;
            }
        }

        public void cook()
        {
            this.currentState = CookedState.Cooked;
            updateSprite();
        }

        public void attatchToPlayer()
        {
            GameObject player = GameManager.getPlayer();
            this.gameObject.transform.parent = player.transform;
            this.gameObject.transform.position = new Vector3(0, 4.2f, -5);
            player.GetComponent<CharacterController2D>().heldFood = this;
            this.gameObject.SetActive(true);

        }

    }
}
