using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    public Transform lane1;
    public Transform lane2;

    [SerializeField] private float _speed = 10f;
    private bool onLane1 = true;
    private bool isRunning = true;
    private bool isChanging = true;
    

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        _startPosition = lane1.position;
        _startRotation = Quaternion.Euler(-90f, 0f, 180f);

        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }

    void FixedUpdate()
    {
        if (isRunning)
        {
            Vector3 currentVelocity = rb.velocity;
            currentVelocity.x = -_speed;
            rb.velocity = currentVelocity;
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A) && isChanging)
        {
            ChangeLane();
        }
    }

    private void ChangeLane()
    {
        onLane1 = !onLane1;

        float targetZ = onLane1 ? lane1.position.z : lane2.position.z;

        // Tween chuyển làn
        Sequence laneChangeSeq = DOTween.Sequence();
        laneChangeSeq.Append(transform.DOMoveZ(targetZ, 0.7f).SetEase(Ease.OutCubic));
        laneChangeSeq.Join(transform.DOShakeRotation(
            duration: 0.2f,
            strength: new Vector3(0, 0, 5f),
            vibrato: 10,
            randomness: 50f
        ));
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
        isChanging = true;
        isRunning = true;
        SenceManager.Instance.isGoing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("VatCan"))
        {
            
            SenceManager.Instance.isGoing = true;
            SenceManager.Instance.SetActiveCarCome();
            isChanging = false;
            float targetZ = (lane1.position.z + lane2.position.z)/2;

            // Tween chuyển làn
            Sequence laneChangeSeq = DOTween.Sequence();
            laneChangeSeq.Append(transform.DOMoveZ(targetZ, 0.7f).SetEase(Ease.OutCubic));
            laneChangeSeq.Join(transform.DOShakeRotation(
                duration: 0.2f,
                strength: new Vector3(0, 0, 5f),
                vibrato: 10,
                randomness: 50f
            ));
        }
    }
}
