using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Collision
{
    /// <summary>
    /// A script to be placed on all objects that deal with collision to check if the target object has entered one of it's colliders.
    /// </summary>
    public class CollisionChecker:MonoBehaviour
    {
        /// <summary>
        /// The target game object tag to collide with.
        /// </summary>
        public string targetTag;
        /// <summary>
        /// Checks if a game object with the appropriate tag has entered a collider.
        /// </summary>
        public bool targetEntered;

        /// <summary>
        /// Checks if the target game object is staying inside the collider zone.
        /// </summary>
        public bool targetStaying;

        /// <summary>
        /// Start.
        /// </summary>
        public void Start()
        {
            //Do nothing.
        }

        /// <summary>
        /// Checks if the target game object has entered into a collider zone.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag ==  targetTag)
            {
                targetEntered = true;
            }
        }

        /// <summary>
        /// Checks if the target game object 
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == targetTag)
            {
                targetStaying = true;
            }
        }

        /// <summary>
        /// Checks if the target game object has left a collider zone.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == targetTag)
            {
                targetEntered = false;
                targetStaying = false;
            }

        }

    }
}
