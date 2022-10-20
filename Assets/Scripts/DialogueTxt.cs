using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueTxt : MonoBehaviour
{
    public static DialogueTxt Instance;

    public Dialogue openingDialogue;
    public Dialogue tutorialDialogue;
    public Dialogue valetCallDialogue;
    public Dialogue saturdayValetCallDialogue;
    public Dialogue goingOutDialogue;
    public Dialogue cultivationDialogue;
    public Dialogue callPeddlerDialogue;
    public Dialogue buyPotionDialogue;
    public Dialogue usePotionDialogue;
    public Dialogue overlapUsePotionDialogue;
    public Dialogue buyChocoDialogue;
    public Dialogue buyPaddlerDialogue;
    public Dialogue cancelShopDialogue;
    public Dialogue placeSelectDialogue;
    public Dialogue homeLockDialogue;
    public Dialogue firstIanDialogue;
    public Dialogue firstNoaDialogue;
    public Dialogue firstAustinDialogue;
        
    private void Awake()
    {
        Instance = this;
    }
}
