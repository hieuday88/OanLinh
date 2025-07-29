using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject phone;
    public GameObject finall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finally"))
        {
            finall.SetActive(false);
            phone.SetActive(true);
        }
    }
}