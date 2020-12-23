using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowInputSystem : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject windowInputSystem;
    [SerializeField] private int sceneIndex;
    private Transform windowInputTransform;

    void Start()
    {
        windowInputTransform = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(2);

        if(player.indexScene == 0)
        {
            //&& SceneManager.GetActiveScene().buildIndex == sceneIndex
            Time.timeScale = 0;
            Instantiate(windowInputSystem, windowInputTransform);
        }
    }
}
