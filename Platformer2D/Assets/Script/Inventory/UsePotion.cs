using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotion : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UsePotionHealth(int health)
    {
        Debug.Log("Use");
        Player.PlayerInstance.health += health;
        Destroy(gameObject);
    }
}
