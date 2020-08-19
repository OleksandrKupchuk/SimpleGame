using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Player player;
    public GameObject loadingScreen;
    public Slider slider;
    public Text textProgress;

    public void StartGame(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
        Time.timeScale = 1;
        //SceneManager.LoadScene(indexScene);
    }

    public void LoadGame()
    {
        StartCoroutine(LoadAsynchronously(player.indexScene));
        Debug.Log("scene index = " + player.indexScene);
        Time.timeScale = 1;
    }

    public void LoadScene(int index)
    {
        StartCoroutine(LoadAsynchronously(index));
        Time.timeScale = 1;
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);
        
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            textProgress.text = progress * 100 + "%";

            yield return null;
        }
    }

    public void ExitGame()
    {
        //Debug.Log("Exit");
        Application.Quit();
    }
}
