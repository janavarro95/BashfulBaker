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
            this.warpSound.Play();
            DestroyObject(GameManager.getPlayer());
            GameManager.getPlayer().transform.localScale = new Vector3(2f, 2f, 1);
            base.afterWarp();
        }
    }
}
