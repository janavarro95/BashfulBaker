using Assets.Scripts;
using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Objects.WarpTiles
{

    public class WarpToOutdoors : WarpTile
    {
        public override void afterWarp()
        {
            this.warpSound.Play();
            GameManager.getPlayer().transform.localScale = new Vector3(0.5f, 0.5f, 1);
            base.afterWarp();
        }
    }

}