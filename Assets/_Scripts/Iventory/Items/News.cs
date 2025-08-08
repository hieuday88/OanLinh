using System.Collections;
using TMPro;
using UnityEngine;

public class News : MonoBehaviour, IInteractable
{
    [TextArea(10, 20)]
    public string text;
    public string title;

    public bool isReading = false;

    public void OnInteract()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance.read);
        if (!isReading)
        {
            ShowNews();
        }
    }

    private void ShowNews()
    {
        PlayerInteraction.Instance.desText.GetComponentInChildren<TextMeshProUGUI>().text = text;

        PlayerInteraction.Instance.desText.gameObject.SetActive(true);
        PlayerInteraction.Instance.isBusy = true;
        IventoryManager.Instance.canUseItem = false;
        isReading = true;
    }

    private void Update()
    {
        if (isReading && Input.GetMouseButtonDown(1))
        {
            HideNews();
        }
    }

    private void HideNews()
    {
        PlayerInteraction.Instance.desText.gameObject.SetActive(false);
        PlayerInteraction.Instance.isBusy = false;
        IventoryManager.Instance.canUseItem = true;
        isReading = false;
    }

    public string Infor()
    {
        return title;
    }
}
