using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject shopWindow;
    private GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        Transform childCanvas = canvas.transform.GetChild(4);
        Instantiate(playerObject, transform.position, Quaternion.identity);
        Instantiate(gameManager, transform.position, Quaternion.identity);
        GameObject shop = Instantiate(shopWindow);
        shop.transform.SetParent(childCanvas, false);

    }
}
