using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Image transitionImage;
    public Slider progressBar;
    public AnimationClip transitionAnimation;
    public string sceneToLoad;

    void Start()
    {
        // 開始過場效果
        StartCoroutine(PlayTransition());
    }

    IEnumerator PlayTransition()
    {
        // 播放過場動畫
        Animation animation = transitionImage.gameObject.AddComponent<Animation>();
        animation.AddClip(transitionAnimation, "Transition");
        animation.Play("Transition");

        // 開始異步載入新場景
        yield return StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncLoad.isDone)
        {
            // 更新進度條
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            progressBar.value = progress;

            // 在這裡可以更新進度條 UI，例如顯示一個進度條

            yield return null; // 等待一幀
        }
    }
}