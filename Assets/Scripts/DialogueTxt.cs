using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTxt : MonoBehaviour
{
    public static DialogueTxt Instance;

    public Dialogue openingDialogue;
    public Dialogue tutorialDialogue;
    public Dialogue valetCallDialogue;
    public Dialogue cultivationDialogue;
    public Dialogue callPeddlerDialogue;
    public Dialogue buyPaddlerDialogue;
    public Dialogue cancelShopDialogue;

    private void Awake()
    {
        Instance = this;
    }
}
