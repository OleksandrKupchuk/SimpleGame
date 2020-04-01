using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
}
