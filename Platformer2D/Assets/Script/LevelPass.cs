using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : MonoBehaviour
{
    [SerializeField] private ObjectdataLoad objectDataLoad;
    [SerializeField] private MainMenu mainMenu;
    private Player playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SavePlayerData();
            RunLevel();
        }
    }

    private void SavePlayerData()
    {
        objectDataLoad.SavePlayer();
    }

    public void RunLevel()
    {
        Invoke("NextLevel", 0.5f);
    }

    private void NextLevel()
    {
        mainMenu.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
