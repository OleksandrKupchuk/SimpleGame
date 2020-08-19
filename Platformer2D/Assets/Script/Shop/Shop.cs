using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private GameObject shopWindow;
    private ShopWindow shopWindowScript;

    void Start()
    {
        shopWindow = GameObject.FindGameObjectWithTag("Shop").gameObject;
        shopWindowScript = shopWindow.gameObject.GetComponent<ShopWindow>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        shopWindow.SetActive(true);
        shopWindowScript.InitializationPlayerParametrs();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        shopWindow.SetActive(false);
    }
}
