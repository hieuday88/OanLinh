
using UnityEngine;

public class Paper1 : MonoBehaviour, IInteractable
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
}
