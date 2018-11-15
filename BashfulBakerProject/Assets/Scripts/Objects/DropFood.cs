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
    public class DropFood:MonoBehaviour{

        public Tilemap tilemap;
        CollisionChecker collision;
        public TileBase dessert;
        public void Start()
        {
            this.gameObject.AddComponent<CollisionChecker>();
            this.collision = this.gameObject.GetComponent<CollisionChecker>();
            this.collision.targetTag = "Player";
        }

        void Update()
        {
            if (collision.targetEntered)
            {
                Drop();
            }
        }

        void Drop()
        {
            Vector3Int pos = new Vector3Int();
            pos.Set((int) this.transform.position.x, (int)this.transform.position.y - 1, (int)this.transform.position.z);
            tilemap.SetTile(pos, dessert);

        }
    }
}