using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicButtonManager : Singleton<GraphicButtonManager>
{
    public Image[] toggleButtons;
    public Sprite onSprite;
    public Sprite offSprite;

    private string key = "ToggleButtonIndex";
    private void Start()
    {
        int index = PlayerPrefs.GetInt(key, 0);
        SetToggleButtons(index);
    }
    public void SetToggleButtons(int index)
    {
        for (int i = 0; i < toggleButtons.Length; i++)
        {
            if (i == index)
            {
                toggleButtons[i].sprite = onSprite;
            }
            else
            {
                toggleButtons[i].sprite = offSprite;
            }

        }
        PlayerPrefs.SetInt(key, index);
    }
}
