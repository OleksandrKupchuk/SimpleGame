using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmountAbility : MonoBehaviour
{
    public int amount;
    private TextMeshProUGUI textAmount;

    void Start()
    {
        textAmount = GetComponent<TextMeshProUGUI>();
        textAmount.text = "+ " + amount;
    }
}
