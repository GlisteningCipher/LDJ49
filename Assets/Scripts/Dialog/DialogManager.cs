using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles showing dialog at certain points of game.
/// </summary>
public class DialogManager : MonoBehaviour
{
    public Dialog.DialogBox Box;
    public List<DialogBark> tiltBarks; // List of all barks that play when the boat tilts
    public List<DialogBark> purchaseBarks; // when a purchase is made
    public List<DialogBark> scoreBarks; // when 3x score get!
    public List<DialogBark> failureBarks; // when a ball has failed to get in for a while
    public List<DialogBark> inactivityBarks; // when the player is inactive

    public void ShowTiltBark()
    {
        if(!Box.isShowingDialog) Box.ShowDialogBark(tiltBarks[Random.Range(0, tiltBarks.Count)]);
    }

    public void ShowPurchaseBark()
    {
        if (!Box.isShowingDialog) Box.ShowDialogBark(purchaseBarks[Random.Range(0, purchaseBarks.Count)]);
    }

    public void ShowScoreBark()
    {
        if (!Box.isShowingDialog) Box.ShowDialogBark(scoreBarks[Random.Range(0, scoreBarks.Count)]);
    }

    public void ShowFailureBark()
    {
        if (!Box.isShowingDialog) Box.ShowDialogBark(failureBarks[Random.Range(0, failureBarks.Count)]);
    }

    public void ShowInactivityBark()
    {
        if (!Box.isShowingDialog) Box.ShowDialogBark(inactivityBarks[Random.Range(0, inactivityBarks.Count)]);
    }
}
