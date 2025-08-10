using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    void Start()
    {
        //cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Luôn hướng về camera
        transform.LookAt(transform.position + cam.forward);
    }
}
