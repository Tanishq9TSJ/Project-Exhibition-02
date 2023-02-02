using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public string sceneToLoad;
    public Slider progressBar;
    public TextMeshProUGUI percentageText;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!operation.isDone)
        {
            progressBar.value = operation.progress;
            percentageText.text = (operation.progress * 100f).ToString("0") + "%";
            yield return null;
        }
    }
}
