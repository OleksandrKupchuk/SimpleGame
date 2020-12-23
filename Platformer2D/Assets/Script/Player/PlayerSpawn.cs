using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject shopWindow;
    [SerializeField] private ObjectdataLoad objectLoad;
    private GameObject canvas;
    [SerializeField] private int sceneIndex;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        Transform childCanvas = canvas.transform.GetChild(3);

        Instantiate(playerObject, transform.position, Quaternion.identity);
        Instantiate(gameManager, transform.position, Quaternion.identity);

        if (sceneIndex != 4)
        {
            GameObject shop = Instantiate(shopWindow);
            shop.transform.SetParent(childCanvas, false);
        }
    }
}
