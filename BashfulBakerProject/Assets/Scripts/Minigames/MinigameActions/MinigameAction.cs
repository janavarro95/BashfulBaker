using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Minigames.MinigameActions
{
    /// <summary>
    /// A base class for all minigames.
    /// </summary>
    /// 
    [Serializable]
    public class MinigameAction
    {

        /// <summary>
        /// Override this to check when a minigame is finished.
        /// </summary>
        /// <returns></returns>
        public virtual bool finished()
        {

            return false;
        }


        /// <summary>
        /// Ovverride this to check when a minigame need's it's values to be incremented.
        /// </summary>
        public virtual void checkForUpdate()
        {

        }

    }
}
