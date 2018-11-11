using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Minigames.MinigameActions
{
    public class ButtonSequenceAction:MinigameAction
    {
        public List<ButtonPressedAction> buttonsToPress;
        public int currentIndex;
        public ButtonPressedAction currentButton
        {
            get
            {
                try
                {
                    return buttonsToPress.ElementAt(currentIndex);
                }
                catch(Exception err)
                {
                    return buttonsToPress.ElementAt(buttonsToPress.Count - 1);
                }
            }
        }


        public ButtonSequenceAction()
        {
            this.buttonsToPress = new List<ButtonPressedAction>();
        }

        public void addButton(ButtonPressedAction button)
        {
            this.buttonsToPress.Add(button);
        }

        /// <summary>
        /// Checks if the most recent button has been pressed and if so, go to the next in the sequence.
        /// </summary>
        public override void checkForUpdate()
        {
            if (currentIndex == buttonsToPress.Count) return;

            currentButton.checkForUpdate();
            if (currentButton.finished())
            {
                incrementToNextButton();
            }
        }

        /// <summary>
        /// Increment the button to the next count.
        /// </summary>
        public void incrementToNextButton()
        {
            if (currentIndex == buttonsToPress.Count) return;
            currentIndex++;
        }

        /// <summary>
        /// Checks if all buttons in the sequence have been pressed.
        /// </summary>
        /// <returns></returns>
        public override bool finished()
        {
            return currentIndex == buttonsToPress.Count;
        }

    }
}
