using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data for single dialog bark.
/// </summary>
[CreateAssetMenu(menuName = "DialogBark")]
public class DialogBark : ScriptableObject
{
    public Sprite PortraitSpriteDay;
    public Sprite PortraitSpriteNight;
    [TextArea()]
    public string DialogText;
}
