using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GameInput
{
    public class InputControls:MonoBehaviour
    {
        /// <summary>
        /// Property to check if the "A" button is pressed.
        /// </summary>
        public static bool APressed
        {
            get
            {
                return Input.GetButtonDown("Fire1");
            }
        }

        /// <summary>
        /// Property to check if the "B" button is pressed.
        /// </summary>
        public static bool BPressed
        {
            get
            {
                return Input.GetButtonDown("Fire2");
            }
        }

        /// <summary>
        /// Property to check if the "X" button is pressed.
        /// </summary>
        public static bool XPressed
        {
            get
            {
                return Input.GetButtonDown("Fire3");
            }
        }

        /// <summary>
        /// Property to check if the "Y" button is pressed.
        /// </summary>
        public static bool YPressed
        {
            get
            {
                return Input.GetButtonDown("Fire4");
            }
        }

        /// <summary>
        /// Property to check if the start button is pressed.
        /// </summary>
        public static bool startPressed
        {
            get
            {
                return Input.GetButtonDown("Start");
            }
        }

        /// <summary>
        /// Property to check if the select button is pressed.
        /// </summary>
        public static bool selectPressed
        {
            get
            {
                return Input.GetButtonDown("Select");
            }
        }

        /// <summary>
        /// Get the input for the triggers.
        /// </summary>
        public static float triggers
        {
            get
            {
                return Input.GetAxis("Triggers");
            }
        }

        /// <summary>
        /// Get the input for the left bummper.
        /// </summary>
        public static bool leftBummperDown
        {
            get
            {
                return Input.GetButtonDown("LeftBummper");
            }
        }

        /// <summary>
        /// Get the input for the rightBummper
        /// </summary>
        public static bool rightBummperDown
        {
            get
            {
                return Input.GetButtonDown("RightBummper");
            }
        }

    }
}
