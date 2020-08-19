using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private Transform coinObject;
    private Transform abilityObject;

    void Start()
    {
        coinObject = transform.GetChild(7).transform;
        abilityObject = transform.GetChild(4).transform;
        //InitializationPrice();
    }

    void Update()
    {

    }

    public void AddAmountAbility(int number)
    {
        int price = coinObject.transform.GetChild(1).transform.GetChild(number).gameObject.GetComponent<PriceAbility>().price;

        int amountAbility = abilityObject.GetChild(number).GetComponent<AmountAbility>().amount;

        if (GameManager.GameManagerInstance.countCoin >= price)
        {
            GameManager.GameManagerInstance.countCoin -= price;

            //Debug.Log("amount = " + amount);
            //Debug.Log("player = " + GameManager.GameManagerInstance.countCoin);

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
        }

        else
        {
            Debug.Log("Недостатньо коштів");
        }

        InitializationPrice();
        InitializationPlayerParametrs();
        GameManager.GameManagerInstance.InitializationCoin();
    }

    public void Text(int number)
    {

    }

    public void InitializationPlayerParametrs()
    {
        damagePlayer.text = "" + Player.PlayerInstance.damage;
        speedPlayer.text = "" + Player.PlayerInstance.speed;
        jumpPlayer.text = "" + Player.PlayerInstance.jumpForce;
    }

    public void InitializationPrice()
    {
        coinObject.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<PriceAbility>().price = priceDamage;
        coinObject.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<PriceAbility>().InitializationText();
        coinObject.transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<PriceAbility>().price = priceSpeed;
        coinObject.transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<PriceAbility>().InitializationText();
        coinObject.transform.GetChild(1).transform.GetChild(2).gameObject.GetComponent<PriceAbility>().price = priceJump;
        coinObject.transform.GetChild(1).transform.GetChild(2).gameObject.GetComponent<PriceAbility>().InitializationText();
    }
}
