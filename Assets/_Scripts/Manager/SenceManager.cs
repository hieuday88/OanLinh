using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceManager : MonoBehaviour
{
    public static SenceManager Instance;
    [SerializeField] private GameObject carCome1;
    [SerializeField] private GameObject carCome2;
    public bool isGoing = false;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetActiveCarCome()
    {
        carCome1.SetActive(true);
        carCome2.SetActive(true);
    }
    
}
