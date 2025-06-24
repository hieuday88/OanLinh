using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CarCome : MonoBehaviour
{
    private Rigidbody rb;


    [SerializeField] private float _speed = 10f;
    [SerializeField] CarController _carController;
    private bool onLane1 = true;
    private bool isRunning = true;
    
    

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        _startPosition = gameObject.transform.position;
        _startRotation = Quaternion.Euler(-90f, 180f, 180f);

        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }

    void FixedUpdate()
    {
        
        if (isRunning && SenceManager.Instance.isGoing)
        {
            Vector3 currentVelocity = rb.velocity;
            currentVelocity.x = _speed;
            rb.velocity = currentVelocity;
        }
    }
    

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            StartCoroutine(ResetAfterDelay());
        }
    }

    private IEnumerator ResetAfterDelay()
    {
        // Đợi cho hiệu ứng vật lý (đâm, bay) xảy ra
        yield return new WaitForSeconds(1f);

        isRunning = false;

        // Reset toàn bộ
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = _startPosition;
        transform.rotation = _startRotation;

        // Chờ 1 frame để đảm bảo rigidbody cập nhật xong
        yield return null;

        isRunning = true;
        gameObject.SetActive(false);

    }

    
    
}
