using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PasswordManager : Singleton<PasswordManager>
{
    [SerializeField] private string _password;

    public bool isWin = false;
    private Vector3 _lockInitialScale;

    public void CheckPassword(string password)
    {
        if (password == _password)
        {
            Debug.Log("Password is correct");

            isWin = true;
        }
    }

}
