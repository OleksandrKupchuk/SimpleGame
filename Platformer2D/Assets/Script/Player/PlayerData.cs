using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float playerHealth;
    public float playerMaxHealth;
    public int playerExperience;
    public int playerLevel;
    public int playerCoin;


    //public PlayerData (Player player)
    //{
    //    playerHealth = player.health;
    //    playerMaxHealth = player.PlayerMaxHealth;
    //    playerExperience = player.PlayerCurrentExperience;
    //    playerLevel = player.playerCurrentLevel;
    //}

    public PlayerData(Player player, GameManager gameManager)
    {
        playerHealth = player.health;
        playerMaxHealth = player.PlayerMaxHealth;
        playerExperience = player.PlayerCurrentExperience;
        playerLevel = player.playerCurrentLevel;
        playerCoin = gameManager.countCoin;
    }

}

