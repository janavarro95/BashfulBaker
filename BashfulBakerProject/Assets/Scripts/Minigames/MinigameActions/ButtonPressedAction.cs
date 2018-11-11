using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Minigames.MinigameActions
{
    /// <summary>
    /// A class that checks if a button has been pressed atleast once.
    /// </summary>
    public class ButtonPressedAction:ButtonMashAction
    {
        public ButtonPressedAction(ButtonMashAction.ButtonToMash button):base(1,button)
        {
            
        }

        public override void checkForUpdate()
        {
            base.checkForUpdate();
        }

        public override bool finished()
        {
            return base.finished();
        }

    }
}
