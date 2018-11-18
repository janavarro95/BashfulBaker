using Assets.Scripts.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Objects.WarpTiles
{
    public class WarpTile:MonoBehaviour
    {
        CollisionChecker collision;
        public string targetMapName;
        public Vector2 targetPosition;
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
                UnityEngine.Object.DontDestroyOnLoad(GameManager.getPlayer());
                beforeWarp();
                SceneManager.LoadScene(targetMapName);
                afterWarp();
            }
        }

        public virtual void beforeWarp()
        {

        }

        public virtual void afterWarp()
        {
            GameManager.getPlayer().GetComponent<CharacterController2D>().setPositon(targetPosition);
        }

    }
}
