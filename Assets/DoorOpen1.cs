using UnityEngine;

public class DoorOpen1 : MonoBehaviour, IInteractable
{
    public Key key;
    public string title;
    public void OnInteract()
    {
        DoorController door = gameObject.GetComponent<DoorController>();
        if (door != null && key.isPickedUp)
        {
            title = "Mở cửa";
            door.ToggleDoor();
        }
        else
        {
            title = "Cửa đã khóa";
            door.ToggleDoor();
        }
    }

    public string Infor()
    {
        return title;
    }
}