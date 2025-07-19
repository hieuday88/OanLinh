using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour, IPointerDownHandler
{
    public int index;
    public void OnPointerDown(PointerEventData eventData)
    {
        GraphicButtonManager.Instance.SetToggleButtons(index);
    }
}
