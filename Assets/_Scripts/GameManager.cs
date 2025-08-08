using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject block;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.PlaySFX(SoundManager.Instance.clickClip);
            Debug.Log("click");
            Debug.Log(PlayerInteraction.Instance.isBusy);
        }

        if(PlayerInteraction.Instance.isPlashBack) 
            block.SetActive(true);
    }


}
