using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
   
    void Start()
    {
        
    }

    public void Setup(float damage)
    {
        textMeshPro.SetText(damage.ToString());
    }
}
