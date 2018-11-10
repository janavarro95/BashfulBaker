using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Minigames.MinigameActions
{
    /// <summary>
    /// A class that wraps handling all of the possible actions for a minigame.
    /// 
    /// Put this on a minigame and update it inside the minigame.
    /// </summary>
    public class MinigameActionManager
    {
        /// <summary>
        /// A queue of all of the actions necessary to complete the minigame.
        /// </summary>
        public List<MinigameAction> actions;

        /// <summary>
        /// The index for the current action queue.
        /// </summary>
        public int currentActionIndex;

        /// <summary>
        /// Property to get the current action.
        /// </summary>
        public MinigameAction currentAction {
            get
            {
                try
                {
                    return this.actions.ElementAt(this.currentActionIndex);
                }
                catch(Exception err)
                {
                    return this.actions.ElementAt(actions.Count - 1); //Just incase we go off the end.
                }
            }
        }

        public EventHandler onFinished;


        /// <summary>
        /// Empty constructor.
        /// </summary>
        public MinigameActionManager()
        {
            this.actions = new List<MinigameAction>();
            this.currentActionIndex = 0;
            //this.actions.Add(new CollisionAction(GameManager.getObjectFromScene("DummyCookie")));
        }


        /// <summary>
        /// Add's an action to the end of the minigame action queue.
        /// </summary>
        /// <param name="action"></param>
        public void addAction(MinigameAction action)
        {
            this.actions.Add(action);
        }


        /// <summary>
        /// Checks if the current action is finished.
        /// </summary>
        /// <returns></returns>
        public bool currentActionFinished()
        {
            return this.currentAction.finished();
        }

        /// <summary>
        /// Goes to the next action when the current one is finished.
        /// </summary>
        public void nextActionIfFinished()
        {
            if (currentActionFinished() && finishedAll()==false)
            {
                this.currentActionIndex++;
            }
        }

        /// <summary>
        /// Checks if all minigame actions have been finished.
        /// </summary>
        /// <returns></returns>
        public bool finishedAll()
        {
            if (this.currentActionIndex >= this.actions.Count)
            {
                return true;
            }
            else return false;
        }


        /// <summary>
        /// Checks if the actions's conditions have been met and then increments it.
        /// </summary>
        public void checkForUpdate()
        {
            if (currentAction is ButtonMashAction)
            {
                (currentAction as ButtonMashAction).checkForUpdate();
            }
        }

        public void Update()
        {
            if (currentActionFinished())
            {
                nextActionIfFinished();
            }
        }

    }
}
