using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Minigames.MinigameActions
{

    /// <summary>
    /// A class that acts as a minigame action to make the player mash a button a ton.
    /// </summary>
    public class ButtonMashAction : MinigameAction
    {

        /// <summary>
        /// An enum to handle what button is associated with this action.
        /// </summary>
        public enum ButtonToMash
        {
            A,
            B,
            X,
            Y
        }

        /// <summary>
        /// The corresponding button to press.
        /// </summary>
        public ButtonToMash mashButton;

        /// <summary>
        /// The number of times the button has been pressed.
        /// </summary>
        public int numberOfTimesClicked;

        /// <summary>
        /// The target number of times to press the button.
        /// </summary>
        public int targetNumberOfTimesClicked;


        /// <summary>
        /// Empty constructor.
        /// </summary>
        public ButtonMashAction()
        {
            this.numberOfTimesClicked = 0;
            this.targetNumberOfTimesClicked = 0;
            this.mashButton = ButtonToMash.A;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="TargetNumber">The target number for times mashed.</param>
        /// <param name="Button">The button to mash.</param>
        public ButtonMashAction(int TargetNumber,ButtonToMash Button)
        {
            this.numberOfTimesClicked = 0;
            this.targetNumberOfTimesClicked = TargetNumber;
            this.mashButton = Button;
        }

        /// <summary>
        /// Increment the number of times clicked.
        /// </summary>
        public void increment()
        {
            numberOfTimesClicked++;
        }

        /// <summary>
        /// Checks if the button has been pressed a certain number of times.
        /// </summary>
        /// <returns></returns>
        public override bool finished()
        {
            return this.numberOfTimesClicked >= targetNumberOfTimesClicked;
            //return base.finished();
        }

        /// <summary>
        /// Checks to see if this button mash's action appropriate button has been pressed and if so, update it's button pressed count.
        /// </summary>
        public override void checkForUpdate()
        {
            if(GameInput.InputControls.APressed && this.mashButton== ButtonToMash.A)
            {
                increment();
            }
            if (GameInput.InputControls.BPressed && this.mashButton == ButtonToMash.B)
            {
                increment();
            }
            if (GameInput.InputControls.XPressed && this.mashButton == ButtonToMash.X)
            {
                increment();
            }
            if (GameInput.InputControls.YPressed && this.mashButton == ButtonToMash.Y)
            {
                increment();
            }
        }

    }
}
