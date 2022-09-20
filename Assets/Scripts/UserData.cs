using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "UserData")]
public class UserData : ScriptableObject
{
    public bool isOpening;

    public string userName;
}
