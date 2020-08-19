using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCombatText : MonoBehaviour
{
    [SerializeField] private Transform combatText;
    void Start()
    {
        Transform damageTransform = Instantiate(combatText, transform.position, Quaternion.identity);
        DamagePopup damagePopup = damageTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(120);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
