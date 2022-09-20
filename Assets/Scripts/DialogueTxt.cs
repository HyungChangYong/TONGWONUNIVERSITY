using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTxt : MonoBehaviour
{
    public static DialogueTxt Instance;

    public Dialogue openingDialogue;
    public Dialogue tutorialDialogue;
    
    private void Awake()
    {
        Instance = this;
    }
}
