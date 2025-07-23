using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class LoadSceneManager : Singleton<LoadSceneManager>
{
    public Image fadeImage;

    public float fadeDuration = 0.5f;

    public bool save;

    void Update()
    {
        if (save)
            SaveManager.Instance.SaveGame();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(IELoadScene(sceneName));
    }

    private IEnumerator IELoadScene(string sceneName)
    {
        SetAlpha(0f);
        yield return fadeImage.DOFade(1f, fadeDuration).SetEase(Ease.InOutSine).WaitForCompletion();
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return null;
        yield return null;
        //SaveManager.Instance.LoadGame();
        yield return fadeImage.DOFade(0f, fadeDuration).SetEase(Ease.InOutSine).WaitForCompletion();

    }

    private void SetAlpha(float alpha)
    {
        var color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }
}
