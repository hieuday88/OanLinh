using UnityEngine;

public class DoorOpen2 : MonoBehaviour, IInteractable
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public string title;
    public void OnInteract()
    {
        DoorController door = gameObject.GetComponent<DoorController>();
        if (door != null && p1.activeSelf && p2.activeSelf && p3.activeSelf && p4.activeSelf)
        {
            title = "Mở tủ";
            door.ToggleDoor();
        }
        else
        {
            title = "Cửa đã khóa bởi thứ gì đó";
        }
    }

    public string Infor()
    {
        return title;
    }
}