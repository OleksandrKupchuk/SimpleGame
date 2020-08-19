using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : MonoBehaviour
{
    [SerializeField] private ObjectdataLoad objectDataLoad;
    [SerializeField] private MainMenu mainMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //save data and load next scene
            objectDataLoad.SavePlayer();
            //yield return new WaitForSeconds(2f);
            mainMenu.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            objectDataLoad.LoadPlayer();
        }
    }

    //private IEnumerator NextLevel()
    //{
    //    objectDataLoad.SavePlayer();
    //    //yield return new WaitForSeconds(2f);
    //    mainMenu.NextLevel(SceneManager.GetActiveScene().buildIndex + 1);
    //    objectDataLoad.LoadPlayer();
    //    yield return null;
    //}
}
