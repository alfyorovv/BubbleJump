using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    public GameObject loadingPanel;
    public Image loadingProgress;

    public IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1); //Loading scene 1 (main scene)

        loadingPanel.SetActive(true);

        while(!operation.isDone)
        {
            float progressaValue = operation.progress;
            loadingProgress.fillAmount = progressaValue;

            yield return null;
        }
    }

}
