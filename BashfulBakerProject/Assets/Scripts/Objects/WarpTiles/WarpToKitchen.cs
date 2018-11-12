using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Objects.WarpTiles
{
    public class WarpToKitchen : WarpTile
    {

        public override void afterWarp()
        {
            GameManager.getPlayer().transform.localScale = new Vector3(2f, 2f, 1);
            //Destroy(GameObject.FindGameObjectsWithTag("Player").ElementAt(0));

            
            base.afterWarp();
        }
    }
}
