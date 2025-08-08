using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flashback : MonoBehaviour, IInteractable
{
    public string title = "Có một ký ức mơ hồ ở đây";
    public GameObject note;
    public GameObject end;
    public void OnInteract()
    {
        PlayerInteraction.Instance.StartFlashbackStrongNoise();
        
        DOVirtual.DelayedCall(0.5f, () =>
        {

            if (!SceneManager.GetSceneByName("Flashback").isLoaded)
            {
                SceneManager.LoadSceneAsync("Flashback", LoadSceneMode.Additive).completed += (op) =>
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Flashback"));
                };
            }
            else
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Flashback"));
            }

            title = "";

            DOVirtual.DelayedCall(1f, () =>
            {
                note.SetActive(true);
                end.SetActive(true);
            });
            
        });
        
    }

    public string Infor()
    {
        return title;
    }
}