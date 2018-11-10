using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Collision
{
    public class BoxCollision2D:MonoBehaviour
    {
        public GameObject targetGameObject;
        public BoxCollider2D gameObjectCollider;

        public void Start()
        {
            this.gameObjectCollider = targetGameObject.GetComponent<BoxCollider2D>();
        }



    }
}
