using UnityEngine;
using UnityEngine.SceneManagement;

public class Flashback : MonoBehaviour, IInteractable
{
    public string title = "Có một ký ức mơ hồ ở đây";
    public void OnInteract()
    {
        // Nếu scene "Flashback" chưa được load, load nó ở chế độ additive
        if (!SceneManager.GetSceneByName("Flashback").isLoaded)
        {
            SceneManager.LoadSceneAsync("Flashback", LoadSceneMode.Additive).completed += (op) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Flashback"));
            };
        }
        else
        {
            // Nếu đã load rồi thì chỉ cần chuyển active
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Flashback"));
        }

        title = "";
    }

    public string Infor()
    {
        return title;
    }
}