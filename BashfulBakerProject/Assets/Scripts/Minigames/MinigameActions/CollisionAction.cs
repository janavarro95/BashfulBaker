using Assets.Scripts.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Minigames.MinigameActions
{
    public class CollisionAction:MinigameAction
    {
        /// <summary>
        /// The target game object that has this collision checking script.
        /// </summary>
        public CollisionChecker collider;


        public CollisionAction()
        {

        }

        public CollisionAction(string targetTag)
        {
            this.collider = new CollisionChecker();
            this.collider.tag = targetTag;
        }


        public CollisionAction(GameObject target)
        {
            this.collider = target.GetComponent<CollisionChecker>();
        }



        /// <summary>
        /// Checks if the target object has collided with 
        /// </summary>
        public bool hasCollided
        {
            get
            {
                return collider.targetEntered;
            }
        }

        /// <summary>
        /// Checks if the target object has been collided with.
        /// </summary>
        /// <returns></returns>
        public override bool finished()
        {
            return this.hasCollided;
        }
    }
}
