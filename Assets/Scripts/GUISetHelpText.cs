using UnityEngine;
using System.Collections;
using System;

public class GUISetHelpText : MonoBehaviour
{
    void Start()
    {
        this.guiText.text =
                "HOW TO PLAY"
            + Environment.NewLine
            + Environment.NewLine
            + "Press the space bar when the cubes are close."
            + Environment.NewLine
            + "Get the closest for the best score!"
            + Environment.NewLine
            + Environment.NewLine
            + "Successful counters will increase the multiplyer and speed."
            + Environment.NewLine
            + "Missing will decrease multiplyer and speed."
            + Environment.NewLine
            + Environment.NewLine
            + "Try and get the highest score within the time limit!"
            + Environment.NewLine
            + Environment.NewLine
            + Environment.NewLine
            + "You can use the \"Escape\" key to access menu options.";
    }
}
