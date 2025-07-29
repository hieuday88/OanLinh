using UnityEngine;

public class Flashlight : MonoBehaviour, IInteractable, ISaveable
{
    public GameObject lightObject;

    public void OnInteract()
    {
        GetComponent<ItemPickup>().Pickup();
        
        lightObject.SetActive(!lightObject.activeSelf);
        this.gameObject.SetActive(false);
    }

    public string Infor()
    {
        return "Nhấn để nhặt đèn pin";
    }

    [System.Serializable]
    public struct FlashlightSaveData
    {
        public bool lightEnabled;
        public bool isPickedUp;
    }
    public object CaptureState()
    {
        return new FlashlightSaveData
        {
            lightEnabled = lightObject.activeSelf,
            isPickedUp = !gameObject.activeSelf
        };
    }

    public void RestoreState(object state)
    {
        var data = (FlashlightSaveData)state;
        lightObject.SetActive(data.lightEnabled);
        gameObject.SetActive(!data.isPickedUp);
    }


}
