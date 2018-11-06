using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.DialogueSystem
{
    /// <summary>
    /// Basic data structure to handle dialogue.
    /// </summary>
    public class Dialogue
    {
        /// <summary>
        /// All of the sentences in the dialogue.
        /// </summary>
        public List<string> sentences;

        /// <summary>
        /// The current index for the dialogue.
        /// </summary>
        public int index;

        /// <summary>
        /// The current sentence for the dialogue.
        /// </summary>
        public string currentSentence
        {
            get
            {
                if (finished()) return "";
                return sentences.ElementAt(index);
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Dialogue()
        {
            sentences = new List<string>();
            index = 0;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Sentences">All of the sentences for this dialogue.</param>
        public Dialogue(List<string> Sentences)
        {
            this.sentences = Sentences;
            this.index = 0;
        }

        /// <summary>
        /// Go to the next index in the dialogue.
        /// </summary>
        public void next()
        {
            if (index >= sentences.Count) return;
            else index++;
        }

        /// <summary>
        /// Add a sentence to the end of the dialogue sequence.
        /// </summary>
        /// <param name="sentence"></param>
        public void addSentence(string sentence)
        {
            if (String.IsNullOrEmpty(sentence)) return; //Don't add in bad sentences.
            this.sentences.Add(sentence);
        }

        /// <summary>
        /// Checks if the dialogue sequence is finished or not.
        /// </summary>
        /// <returns></returns>
        public bool finished()
        {
            if (this.index >= this.sentences.Count) return true;
            return false;
        }

    }
}
