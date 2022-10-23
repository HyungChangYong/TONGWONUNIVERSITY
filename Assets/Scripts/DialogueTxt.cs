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
    public Dialogue nobodyElseDialogue;
    public Dialogue townIan1Dialogue;
    public Dialogue townIan2Dialogue;
    public Dialogue townIan2FunDialogue;
    public Dialogue townIan2TiresomeDialogue;
    public Dialogue townIan2SelectDialogue;
    public Dialogue townIan3Dialogue;
    public Dialogue townIan3HiDialogue;
    public Dialogue townIan3IgnoreDialogue;
    public Dialogue townIan4Dialogue;
    public Dialogue townNoa1Dialogue;
    public Dialogue townNoa1MistakeDialogue;
    public Dialogue townNoa1StandDialogue;
    public Dialogue townNoa1SelectDialogue;
    public Dialogue townNoa1SelectNextDialogue;
    public Dialogue townNoa2Dialogue;
    public Dialogue townNoa2NextDialogue;
    public Dialogue townNoa3Dialogue;
    public Dialogue townNoa4Dialogue;
    public Dialogue townNoa4CheerDialogue;
    public Dialogue townNoa4QuestionDialogue;
    public Dialogue townNoa4SelectDialogue;
    public Dialogue townAustin1Dialogue;
    public Dialogue townAustin2Dialogue;
    public Dialogue townAustin2FireFestivalDialogue;
    public Dialogue townAustin2AroundDialogue;
    public Dialogue townAustin3Dialogue;
    public Dialogue townAustin4Dialogue;
    public Dialogue townAustin4NextDialogue;

    private void Awake()
    {
        Instance = this;
    }
}
