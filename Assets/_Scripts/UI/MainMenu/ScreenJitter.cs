using UnityEngine;

public class ScreenJitter : MonoBehaviour
{
    public float jitterAmount = 1f;
    public float jitterSpeed = 30f;

    private RectTransform rectTransform;
    private Vector3 originalPosition;
    private float timer;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        timer += Time.deltaTime * jitterSpeed;
        float offsetX = (Mathf.PerlinNoise(timer, 0f) - 0.5f) * jitterAmount * 2;
        float offsetY = (Mathf.PerlinNoise(0f, timer) - 0.5f) * jitterAmount * 2;

        rectTransform.anchoredPosition = originalPosition + new Vector3(offsetX, offsetY, 0f);

        Debug.Log("Jitter running: " + rectTransform.anchoredPosition);
    }

    void OnDisable()
    {
        // Reset về vị trí ban đầu
        if (rectTransform != null)
            rectTransform.anchoredPosition = originalPosition;
    }
}