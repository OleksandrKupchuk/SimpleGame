using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    private static ShopWindow shopWindow;

    public static ShopWindow Instance
    {
        get
        {
            if (shopWindow == null)
            {
                shopWindow = FindObjectOfType<ShopWindow>();
            }

            else if (shopWindow != FindObjectOfType<ShopWindow>())
            {
                Destroy(shopWindow);
            }

            return shopWindow;
        }
    }

    [Header("Price ability")]
    public int priceDamage;
    public int priceSpeed;
    public int priceJump;

    [Header("Cost price")]
    public int costDamage;
    public int costSpeed;
    public int costJump;

    [Header("Player amount ability")]
    public TextMeshProUGUI damagePlayer;
    public TextMeshProUGUI speedPlayer;
    public TextMeshProUGUI jumpPlayer;

    [Header("Window error")]
    [SerializeField] private GameObject windowError;

    [SerializeField] private GameObject windowObject;
    private Transform window;
    private Transform coinObject;
    private Transform abilityObject;

    void Start()
    {
        //if (MainMenu.isNewGame == true)
        //{
        //    InitializationPrice();
        //}

        window = transform.GetChild(0).transform;
        coinObject = window.transform.GetChild(7).transform;
        abilityObject = window.transform.GetChild(4).transform;
    }

    void Update()
    {
        if(windowObject.activeSelf == true)
        {
            SetPrice();
        }
    }

    public void AddAmountAbility(int number)
    {
        //GameObject button = window.transform.GetChild(2).transform.GetChild(number).gameObject;
        int price = coinObject.transform.GetChild(1).transform.GetChild(number).gameObject.GetComponent<PriceAbility>().price;

        int amountAbility = abilityObject.GetChild(number).GetComponent<AmountAbility>().amount;

        if (GameManager.GameManagerInstance.CountCoin >= price)
        {
            GameManager.GameManagerInstance.CountCoin -= price;

            if (number == 0)
            {
                Player.PlayerInstance.damage += amountAbility;
                priceDamage += costDamage;
            }

            if (number == 1)
            {
                Player.PlayerInstance.speed += amountAbility;
                priceSpeed += costSpeed;
            }

            if (number == 2)
            {
                Player.PlayerInstance.jumpForce += amountAbility;
                priceJump += costJump;
            }

            SoundManager.soundManagerInstance.PlaySound("Buy_Ability");
        }

        else
        {
            windowError.SetActive(true);
            Debug.Log("Недостатньо коштів");
        }

        SetPrice();
        InitializationPlayerParametrs();
        //GameManager.GameManagerInstance.SetCoin();
    }

    public void InitializationPlayerParametrs()
    {
        damagePlayer.text = "" + Player.PlayerInstance.damage;
        speedPlayer.text = "" + Player.PlayerInstance.speed;
        jumpPlayer.text = "" + Player.PlayerInstance.jumpForce;
    }

    public void SetPrice()
    {
        coinObject.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<PriceAbility>().price = priceDamage;
        coinObject.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<PriceAbility>().InitializationText();
        coinObject.transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<PriceAbility>().price = priceSpeed;
        coinObject.transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<PriceAbility>().InitializationText();
        coinObject.transform.GetChild(1).transform.GetChild(2).gameObject.GetComponent<PriceAbility>().price = priceJump;
        coinObject.transform.GetChild(1).transform.GetChild(2).gameObject.GetComponent<PriceAbility>().InitializationText();
    }

    public void InitializationPrice()
    {
        priceDamage = 10;
        priceSpeed = 9;
        priceJump = 12;
    }
}
