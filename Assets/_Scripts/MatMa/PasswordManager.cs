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
    public GameObject passwordObject;
    public TextMeshProUGUI wrongText;

    public void CheckPassword(string password)
    {
        if (password == _password)
        {
            Debug.Log("Password is correct");

            isWin = true;
        }
        else
        {
            WrongPassword();
        }
    }

    public void WrongPassword()
    {
        isWin = false;
        
        // Rung lac
        Vector3 position = passwordObject.transform.position;

        passwordObject.transform.DOKill();
        
        passwordObject.transform.DOShakePosition(0.5f, new Vector3(10f, 0f, 0f),20).OnComplete(()=>
        {
            passwordObject.transform.DOKill();
        });

        wrongText.enabled = true;
        
        Vector3 scale = wrongText.transform.localScale;
        
        wrongText.transform.localScale = Vector3.zero;

        wrongText.transform.DOScale(scale, 0.5f).OnComplete(()=>
        {
            wrongText.transform.localScale = scale;
            wrongText.transform.DOKill();
            wrongText.enabled = false;
        });

    }
    
}
