using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private GameObject shopWindow;
    private ShopWindow shopWindowScript;
    private GameObject window;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Collider2D boxCollider;
    private Collider2D playerSwordCollider;
    private Menu menu;

    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Menu>();
        shopWindow = GameObject.FindGameObjectWithTag("Shop").gameObject;
        window = shopWindow.transform.GetChild(0).gameObject;
        shopWindowScript = shopWindow.gameObject.GetComponent<ShopWindow>();
        playerSwordCollider = playerObject.transform.GetChild(0).gameObject.GetComponent<EdgeCollider2D>();
        Physics2D.IgnoreCollision(playerSwordCollider, boxCollider, true);
        //Debug.Log(playerObject.transform.GetChild(0).name);
    }

    void Update()
    {
        //if (window.activeInHierarchy == true)
        //{
        //    menu.EnableObject(1);
        //}

        //if (window.activeInHierarchy == false)
        //{
        //    menu.EnableObject(2);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "PlayerSword")
        {
            window.SetActive(true);
            shopWindowScript.InitializationPlayerParametrs();
            //Invoke("UpdatePrice", 0.5f);
            Time.timeScale = 0;

            //if(window.activeInHierarchy == true)
            //{
            //    menu.EnableObject(1);
            //}
            //menu.EnableObject(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        window.SetActive(false);
    }

    private void UpdatePrice()
    {
        shopWindowScript.SetPrice();
    }

    public void Close()
    {
        //menu.EnableObject(2);
        Time.timeScale = 1;
    }
}
