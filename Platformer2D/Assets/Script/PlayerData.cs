using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float playerHealth;
    public float playerMaxHealth;
    public int playerExperience;


    public PlayerData (Player player)
    {
        playerHealth = player.health;
        playerMaxHealth = player.PlayerMaxHealth;
        playerExperience = player.CurrentExperience;
    }
}

