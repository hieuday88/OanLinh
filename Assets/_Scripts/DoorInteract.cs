using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    public string title;
    public void OnInteract()
    {
        DoorController door = gameObject.GetComponent<DoorController>();
        if (door != null)
        {
            title = "Mở cửa";
            door.ToggleDoor();
        }
    }

    public string Infor()
    {
        return title;
    }
}