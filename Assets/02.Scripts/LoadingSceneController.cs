using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;
    [SerializeField]
    Slider progressBar;

    public void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    IEnumerator LoadSceneProcess()
    {
       AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
       op.allowSceneActivation = false;
       
       float duration = 3f;
       float timer = 0f;
       while(!op.isDone)
       {
        yield return null;

        if(op.progress < 0.9f)
        {
            progressBar.value = op.progress / 5;
        }
        else
        {
            timer += Time.unscaledDeltaTime;
            var t = Mathf.Clamp01(timer / duration);
            progressBar.value = Mathf.Lerp(0.2f, 1f, t);
            if(progressBar.value >= 1f)
            {
                op.allowSceneActivation = true;
                yield break;
            }
        }
       }
    }
}

