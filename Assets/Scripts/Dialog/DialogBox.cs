using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
    /// <summary>
    /// Manages displaying and scrolling dialog.
    /// </summary>
    [RequireComponent(typeof(TMProFX.ColorOverride))]
    public class DialogBox : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI DialogText; // Text for spoken dialog
        public float DisplayDelay = 0.1f; // How fast text displays
        public int DisplayBatch = 3; // How many characters are displayed at once
        public float HideDelay = 3f; // How long to wait after showing text completely to hide
        public List<string> allLines; // All lines of dialog in order
        public UnityEngine.UI.Image PortraitSpriteSR; // Sprite for portrait

        TMProFX.ColorOverride textHider => GetComponent<TMProFX.ColorOverride>(); // Makes text transparent
        int currLine; // Current line index
        Coroutine displayCR; // Coroutine for displaying text

        /// <summary>
        /// Initialize dialog box.
        /// </summary>
        public void Init()
        {
            if (allLines == null)
                allLines = new List<string>();
            currLine = -1;
            displayCR = null;
        }

        /// <summary>
        /// Add a new line to the end of the current dialog.
        /// </summary>
        /// <param name="newLine">New line.</param>
        public void AddLine(string newLine)
        {
            allLines.Add(newLine);
        }

        /// <summary>
        /// Go to next line (if there is one) and show it.
        /// </summary>
        public void NextLine()
        {
            if (currLine >= allLines.Count)
                throw new UnityException("At the end of dialog.");
            ShowLine(++currLine);
        }

        /// <summary>
        /// Display line of dialog.
        /// </summary>
        public void ShowLine(int ind)
        {
            if (ind < 0 || ind >= allLines.Count)
                throw new UnityException("Invalid dialog line:" + ind);
            if (displayCR != null)
                StopCoroutine(displayCR);
            displayCR = StartCoroutine(ShowLineCR(ind));
        }

        IEnumerator ShowLineCR(int ind)
        {
            string txt = allLines[ind];
            textHider.Indeces[0] = Mathf.Min(DisplayBatch, txt.Length); // Start with first batch shown.
            textHider.Indeces[1] = txt.Length + 1;
            yield return null;
            DialogText.text = txt;
            while (textHider.Indeces[0] < txt.Length)
            {
                yield return new WaitForSeconds(DisplayDelay);
                if (textHider.Indeces[0] + DisplayBatch >= txt.Length)
                    textHider.Indeces[0] = txt.Length;
                else
                    textHider.Indeces[0] += DisplayBatch;
                textHider.UpdateVertices();
            }
            displayCR = null;
        }

        /// <summary>
        /// Add a new line to the end of current dialog and immediately show it.
        /// Hides after some number of seconds.
        /// </summary>
        /// <param name="newLine"></param>
        public void ShowAndHide(string newLine)
        {
            DialogText.text = "";
            gameObject.SetActive(true); // Show blank dialog box
            StartCoroutine(ShowAndHideCR(newLine));
        }
        IEnumerator ShowAndHideCR(string newLine)
        {
            yield return null;
            AddLine(newLine);
            ShowLine(currLine = allLines.Count - 1); // Show dialog
            yield return null;
            yield return new WaitUntil(() => displayCR == null); // Wait for scroll to finish
            yield return new WaitForSeconds(HideDelay); // Wait for delay
            gameObject.SetActive(false); // Hide dialog box
        }

        /// <summary>
        /// Displays a dialog bark.
        /// </summary>
        public void ShowDialogBark(DialogBark bark)
        {
            PortraitSpriteSR.sprite = bark.PortraitSprite;
            ShowAndHide(bark.DialogText);
        }

        private void Awake()
        {
            Init();
        }
    }
}

