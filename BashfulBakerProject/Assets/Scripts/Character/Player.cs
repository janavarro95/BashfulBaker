using Assets.Scripts.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Character
{
    public class Player
    {
        public Food heldFood;

        /// <summary>
        /// The player's movespeed.
        /// </summary>
        public float moveSpeed = 0.05f;

        /// <summary>
        /// Enum to handle player facing direction.
        /// </summary>
        public enum FacingDirection
        {
            Up,
            Right,
            Down,
            Left
        }

        /// <summary>
        /// The direction the player is facing.
        /// </summary>
        public FacingDirection facingDirection;


        /// <summary>
        /// If the player can move or not.
        /// </summary>
        public bool canMove;


        public bool holdingFood
        {

            get
            {
                if (heldFood == null) return false;
                else return true;
            }
        }
    }


}
