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
    public Dialogue townAustin4OutStoreDialogue;
    public Dialogue restaurantIan1Dialogue;
    public Dialogue restaurantIan1EatWellDialogue;
    public Dialogue restaurantIan1QuestionEatDialogue;
    public Dialogue restaurantIan2Dialogue;
    public Dialogue restaurantNoa1Dialogue;
    public Dialogue restaurantNoa2Dialogue;
    public Dialogue restaurantNoa2GoodDialogue;
    public Dialogue restaurantNoa2PerfectDialogue;
    public Dialogue restaurantNoa2SelectDialogue;
    public Dialogue restaurantNoa3Dialogue;
    public Dialogue restaurantNoa3NextDialogue;
    public Dialogue restaurantAustin1Dialogue;
    public Dialogue restaurantAustin2Dialogue;
    public Dialogue restaurantAustin2NextDialogue;
    public Dialogue restaurantAustin2CopyDialogue;
    public Dialogue restaurantAustin2WaitDialogue;
    public Dialogue restaurantAustin2SelectDialogue;
    public Dialogue parkIan1Dialogue;
    public Dialogue parkIan1PlantsDialogue;
    public Dialogue parkIan1NightSkyDialogue;
    public Dialogue parkIan2Dialogue;
    public Dialogue parkIan3Dialogue;
    public Dialogue parkIan3WalkDialogue;
    public Dialogue parkIan3ExerciseDialogue;
    public Dialogue parkIan4Dialogue;
    public Dialogue parkIan5Dialogue;
    public Dialogue parkIan5LookFlowerDialogue;
    public Dialogue parkIan5RestDialogue;
    public Dialogue parkNoa1Dialogue;
    public Dialogue parkNoa1DogDialogue;
    public Dialogue parkNoa1BirdDialogue;
    public Dialogue parkNoa1SelectDialogue;
    public Dialogue parkNoa2Dialogue;
    public Dialogue parkNoa3Dialogue;
    public Dialogue parkNoa3CuriosityPeopleDialogue;
    public Dialogue parkNoa3StupidPeopleDialogue;
    public Dialogue parkNoa3SelectDialogue;
    public Dialogue parkAustin1Dialogue;
    public Dialogue parkAustin2Dialogue;
    public Dialogue parkAustin2TogetherFindDialogue;
    public Dialogue parkAustin2ChasingDialogue;
    public Dialogue parkAustin3Dialogue;
    public Dialogue parkAustin3FriendDialogue;
    public Dialogue parkAustin3StayDialogue;
    public Dialogue parkAustin3SelectDialogue;

    private void Awake()
    {
        Instance = this;
    }
}
