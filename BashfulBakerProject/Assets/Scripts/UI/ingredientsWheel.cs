using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ingredientsWheel : MonoBehaviour
    {

        public enum CSGOArrow
        {
            Center,
            Left,
            Right,
            Up,
            Down

        }

        public CSGOArrow arrowDirection;
        public Sprite upArrow;
        public Sprite downArrow;
        public Sprite leftArrow;
        public Sprite rightArrow;
        public Sprite centerArrow;
        public SpriteRenderer renderer;



        // Use this for initialization
        void Start()
        {
            arrowDirection = CSGOArrow.Center;
            renderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
            
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            float xAmount = Mathf.Abs(input.x);
            float yAmount = Mathf.Abs(input.y);
            Debug.Log(input);
            if (xAmount == 0 && yAmount == 0)
            {
                this.arrowDirection = CSGOArrow.Center;
         
                renderer.sprite = this.centerArrow; //get default
            }
            else if (xAmount > yAmount)
            {
                if (input.x <= 0)
                {
                    this.arrowDirection = CSGOArrow.Left;
                    renderer.sprite = this.leftArrow; //get left
                }

                if (input.x > 0)
                {
                    this.arrowDirection = CSGOArrow.Right;
                    renderer.sprite = this.rightArrow; //get right
                }
            }
            else
            {
                if (input.y <= 0)
                {
                    this.arrowDirection = CSGOArrow.Down;
                    renderer.sprite = this.downArrow; //get up
                }

                if (input.y > 0)
                {
                    this.arrowDirection = CSGOArrow.Up;
                    renderer.sprite = this.upArrow; //get down
                }
            }

            if (GameInput.InputControls.APressed && this.arrowDirection != CSGOArrow.Center)
            {
                string ingredientsWheel = getSelectedIngredient();
                //give ingredient to bowl

            }

        }

        public string getSelectedIngredient()
        {
            if (this.arrowDirection == CSGOArrow.Up)
            {
                return "Egg";
            }else if (this.arrowDirection == CSGOArrow.Down)
            {
                return "Milk";
            }else if (this.arrowDirection == CSGOArrow.Left)
            {
                return "Flour";
            }else 
            {
                return "Sugar";
            }
        }
        

    }

}


