using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{

    public void OnInteract()
    {
        DoorController door = gameObject.GetComponent<DoorController>();
        if (door != null)
        {
            door.ToggleDoor();
        }
    }

    public string Infor()
    {
        return "Open";
    }
}