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
        // �}�l�L���ĪG
        StartCoroutine(PlayTransition());
    }

    IEnumerator PlayTransition()
    {
        // ����L���ʵe
        Animation animation = transitionImage.gameObject.AddComponent<Animation>();
        animation.AddClip(transitionAnimation, "Transition");
        animation.Play("Transition");

        // �}�l���B���J�s����
        yield return StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncLoad.isDone)
        {
            // ��s�i�ױ�
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            progressBar.value = progress;

            // �b�o�̥i�H��s�i�ױ� UI�A�Ҧp��ܤ@�Ӷi�ױ�

            yield return null; // ���ݤ@�V
        }
    }
}