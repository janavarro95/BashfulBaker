using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.DialogueSystem
{
    /// <summary>
    /// A dialogue manager to manager all dialogues.
    /// </summary>
    public class DialogueManager
    {
        /// <summary>
        /// All of the dialogues in the game????
        /// </summary>
        public static Dictionary<string, Dialogue> Dialogues;

        /// <summary>
        /// Initialize the dialogue dictionary.
        /// </summary>
        public static void initialize()
        {
            Dialogues = new Dictionary<string, Dialogue>();

            //LOAD IN ALL DIALOGUES HERE.
            Dialogues.Add("Hello", new Dialogue(new List<string>()
            {
                "Hello World",
                "Goodbye World"
            }));
        }

        /// <summary>
        /// Get the dialogue associated with a specific dialogue key.
        /// </summary>
        /// <param name="dialogueKey">The dialogue key associated with the dialogue.</param>
        /// <returns></returns>
        public static Dialogue getDialogue(string dialogueKey)
        {
            try
            {
                Dialogue dia;
                Dialogues.TryGetValue(dialogueKey, out dia);
                return dia;
            }
            catch(Exception err)
            {
                throw new Exception("Dialogue key does not exist.");
            }
        }

    }
}
