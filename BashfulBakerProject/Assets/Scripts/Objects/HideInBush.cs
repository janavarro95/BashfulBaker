using Assets.Scripts.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Objects
{
    public class HideInBush : MonoBehaviour
    {

        public Tilemap tilemap;
        CollisionChecker collision;
        public Sprite bushSprite;   // A sprite that is attached to the player.
        public TileBase bush_to_hide; // A tile that is nulled when player interacts with it.
        public bool bush_taken = false;
        public void Start()
        {
            this.gameObject.AddComponent<CollisionChecker>();
            this.collision = this.gameObject.GetComponent<CollisionChecker>();
            this.collision.targetTag = "Player";
        }

        void Update()
        {
            if (collision.targetEntered && !bush_taken)
            {
                HideNow();
            }
        }

        void HideNow()
        {
            Vector3Int pos = new Vector3Int();
            pos.Set(-2, -20, 0);
            tilemap.SetTile(pos, null);
            GameManager.getPlayer().GetComponent<SpriteRenderer>().sprite = bushSprite;
        }

        void stopHidingInBush()
        {

        }
    }
}