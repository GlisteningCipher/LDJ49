using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles showing dialog at certain points of game.
/// </summary>
public class DialogManager : MonoBehaviour
{
    public Dialog.DialogBox Box;
    public List<DialogBark> Barks; // List of all barks.

    const float minWait = 8f;
    const float maxWait = 16f;

    private void Start()
    {
        StartCoroutine(BarkLoopCR());
    }

    /// <summary>
    /// Show barks every few random seconds.
    /// </summary>
    /// <returns></returns>
    IEnumerator BarkLoopCR()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            Box.ShowDialogBark(Barks[Random.Range(0, Barks.Count)]);
        }
    }
}
