using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class UnderlineOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image underlineImage; // Gắn Image component, không phải GameObject

    private void Start()
    {
        // Đảm bảo ban đầu alpha = 0
        var color = underlineImage.color;
        color.a = 0f;
        underlineImage.color = color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        underlineImage.DOFade(1f, 0.2f); // Fade in
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        underlineImage.DOFade(0f, 0.2f); // Fade out
    }
}