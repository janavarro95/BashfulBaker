/*
using Assets.Scripts.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Objects
{
    public class WarpTile:MonoBehaviour
    {
        CollisionChecker collision;
        public string targetMapName;

        public void Start()
        {
            this.gameObject.AddComponent<CollisionChecker>();
            this.collision = this.gameObject.GetComponent<CollisionChecker>();
            this.collision.targetTag = "Player";
        }
        public void Update()
        {
            if (collision.targetEntered)
            {
                SceneManager.LoadScene(targetMapName);
            }
        }


    }
}
*/