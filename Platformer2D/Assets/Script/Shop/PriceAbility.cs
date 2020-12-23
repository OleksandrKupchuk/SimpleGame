using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceAbility : MonoBehaviour
{
    [SerializeField] ShopWindow shopWindow;
    private TextMeshProUGUI textPrice;
    public int price;
   
    void Start()
    {
        textPrice = GetComponent<TextMeshProUGUI>();

        InitializationText();
    }

    public void InitializationText()
    {
        textPrice.text = "" + price;
    }
}
