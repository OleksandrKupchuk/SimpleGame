using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBarHealth : MonoBehaviour
{
    [Header("Boss Parametr")]
    [SerializeField] Boss boss;
    [SerializeField] Image imageHealth;

    void Start()
    {
        imageHealth.fillAmount = boss.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
