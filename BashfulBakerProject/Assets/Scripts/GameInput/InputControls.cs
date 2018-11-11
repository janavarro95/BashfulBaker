using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GameInput
{
    public class InputControls:MonoBehaviour
    {

        public enum ControllerType
        {
            Keyboard,
            XBox,
            DualShock
        }

        /// <summary>
        /// Property to check if the "A" button is pressed.
        /// </summary>
        public static bool APressed
        {
            get
            {
                if (getControllerType() == ControllerType.DualShock)
                {
                    return Input.GetButtonDown("Fire1");
                }
                else if (getControllerType() == ControllerType.XBox)
                {
                    return Input.GetButtonDown("Fire1");
                }
                else
                {
                    
                    return Input.GetButtonDown("Fire1");
                }
            }
        }

        /// <summary>
        /// Property to check if the "B" button is pressed.
        /// </summary>
        public static bool BPressed
        {
            get
            {
                if (getControllerType() == ControllerType.DualShock)
                {
                    return Input.GetButtonDown("Fire2");
                }
                else if (getControllerType() == ControllerType.XBox)
                {
                    return Input.GetButtonDown("Fire2");
                }
                else
                {
                    return Input.GetButtonDown("Fire2");
                }
            }
        }

        /// <summary>
        /// Property to check if the "X" button is pressed.
        /// </summary>
        public static bool XPressed
        {
            get
            {
                if (getControllerType() == ControllerType.DualShock)
                {
                    return Input.GetButtonDown("Fire3");
                }
                else if(getControllerType() == ControllerType.XBox)
                {
                    return Input.GetButtonDown("Fire3");
                }
                else
                {
                    return Input.GetButtonDown("Fire3");
                }
            }
        }

        /// <summary>
        /// Property to check if the "Y" button is pressed.
        /// </summary>
        public static bool YPressed
        {
            get
            {             
                if (getControllerType() == ControllerType.DualShock)
                {
                    return Input.GetButtonDown("Fire4");
                }
                else if (getControllerType() == ControllerType.XBox)
                {
                    return Input.GetButtonDown("Fire4");
                }
                else
                {
                    return Input.GetButtonDown("Fire4");
                }
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

        /// <summary>
        /// USed to determine if the user is using a PS3 or XBox controller so that buttons can be mapped properly to inputs.
        /// </summary>
        /// <returns></returns>
        public static ControllerType getControllerType()
        {
            try
            {
                if (Input.GetJoystickNames().ElementAt(0).Contains("DualShock".ToLower()))
                {
                    return ControllerType.DualShock;
                }
                else if (Input.GetJoystickNames().ElementAt(0).Contains("XBox".ToLower()))
                {
                    return ControllerType.XBox;
                }
                else
                {
                    return ControllerType.Keyboard;
                }
            }
            catch(Exception err)
            {
                return ControllerType.Keyboard;
            }
        }

    }
}
