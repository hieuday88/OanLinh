using UnityEngine;

public class Key : MonoBehaviour, IInteractable, ISaveable
{
    public string title;
    public bool isPickedUp = false;

    public void OnInteract()
    {
        GetComponent<ItemPickup>().Pickup();
        isPickedUp = true;
    }

    public string Infor()
    {
        return title;
    }


    [System.Serializable]
    public struct KeyState
    {
        public bool isPickedUp;
        public bool isActive;
    }

    public object CaptureState()
    {
        return new KeyState
        {
            isPickedUp = this.isPickedUp,
            isActive = this.gameObject.activeSelf
        };
    }

    public void RestoreState(object state)
    {
        KeyState saved = (KeyState)state;
        this.isPickedUp = saved.isPickedUp;
        this.gameObject.SetActive(saved.isActive);
    }
}
