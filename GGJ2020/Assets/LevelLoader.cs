using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public void LevelLoad(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));   
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while(!loading.isDone)
        {
            float progress = Mathf.Clamp01(loading.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
    
}
