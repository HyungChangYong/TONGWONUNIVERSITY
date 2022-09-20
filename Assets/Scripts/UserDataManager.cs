using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public static UserDataManager Instance;

    public UserData user;

    private void Awake()
    {
        Instance = this;
    }
}
