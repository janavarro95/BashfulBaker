﻿using Assets.Scripts;
using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpToOutdoors : WarpTile {

    public override void afterWarp()
    {
        GameManager.getPlayer().transform.localScale = new Vector3(0.5f, 0.5f, 1);
        base.afterWarp();
    }
}
