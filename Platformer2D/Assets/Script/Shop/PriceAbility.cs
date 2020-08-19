using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceAbility : MonoBehaviour
{
    public int price;
    private TextMeshProUGUI textPrice;
   
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
