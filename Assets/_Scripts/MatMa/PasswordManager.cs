using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{
    public static PasswordManager Instance;
    
    [SerializeField] private string _password;
    
    public bool isWin = false;
    private Vector3 _lockInitialScale;

    

    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    

    public void CheckPassword(string password)
    {
        if (password == _password)
        {
            Debug.Log("Password is correct");
           
            isWin = true;
        }
    }

    

    
    
}
