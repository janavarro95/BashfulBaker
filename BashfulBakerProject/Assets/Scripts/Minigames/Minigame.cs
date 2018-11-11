using Assets.Scripts.Minigames.MinigameActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Minigames
{
    public class Minigame:MonoBehaviour
    {
        public MinigameActionManager actionManager;

        public Minigame()
        {
            this.actionManager = new MinigameActionManager();
        }

        public void addAction(MinigameAction action)
        {
            this.actionManager.addAction(action);
        }

        public virtual bool finished()
        {
            return actionManager.finishedAll();
        }
    }
}
