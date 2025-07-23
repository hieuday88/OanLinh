using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Hair : MonoBehaviour, IInteractable, ISaveable
{
    public Items doll32;
    private bool haveDoll = false;
    private string hintText = "Một mớ tóc rối bù";

    public void OnInteract()
    {
        foreach (var item in IventoryManager.Instance.items)
        {
            if (item.id == 9)
            {
                IventoryManager.Instance.RemoveItem(item);
                IventoryManager.Instance.AddItem(doll32);
                haveDoll = true;
                this.gameObject.SetActive(false);
                return;
            }
        }

        if (!haveDoll)
        {
            hintText = "Bạn cần một con búp bê";
            DOVirtual.DelayedCall(3f, () =>
            {
                hintText = "Một mớ tóc rối bù";
            });
        }
    }

    public string Infor()
    {
        return hintText;
    }




    public object CaptureState()
    {
        var state = new Dictionary<string, object>();
        state["haveDoll"] = haveDoll;
        state["isActive"] = gameObject.activeSelf;
        return state;
    }


    public void RestoreState(object state)
    {
        var stateDict = state as Dictionary<string, object>;
        if (stateDict == null)
        {
            Debug.LogWarning("RestoreState failed: state is not a valid dictionary.");
            return;
        }

        haveDoll = stateDict.ContainsKey("haveDoll") && (bool)stateDict["haveDoll"];
        gameObject.SetActive(stateDict.ContainsKey("isActive") && (bool)stateDict["isActive"]);
        hintText = haveDoll ? "Một mớ tóc rối bù" : "Bạn cần một con búp bê";
    }

}
