using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplicationLoader : MonoBehaviour
{
    public Slider progressBar = null;

    public int nextScene = 0;

    private bool hasStartedLoading = false;

    private void Start()
    {
        if (!hasStartedLoading)
        {
            hasStartedLoading = true;
            LoadScene(nextScene);
        }
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.value = progress;

            yield return null;
        }
    }
}
