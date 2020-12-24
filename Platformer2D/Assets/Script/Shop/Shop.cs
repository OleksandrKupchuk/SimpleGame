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

    void Start()
    {
        shopWindow = GameObject.FindGameObjectWithTag("Shop").gameObject;
        window = shopWindow.transform.GetChild(0).gameObject;
        shopWindowScript = shopWindow.gameObject.GetComponent<ShopWindow>();
        playerSwordCollider = playerObject.transform.GetChild(0).gameObject.GetComponent<EdgeCollider2D>();
        Physics2D.IgnoreCollision(playerSwordCollider, boxCollider, true);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "PlayerSword")
        {
            window.SetActive(true);
            shopWindowScript.InitializationPlayerParametrs();
            Time.timeScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        window.SetActive(false);
    }

    public void Close()
    {
        Time.timeScale = 1;
    }
}
