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
    public int indexCurrentScene;
    public int playerDamage;
    public int playerSpeed;
    public int playerJump;

    public int shopWindowDamage;
    public int shopWindowSpeed;
    public int shopWindowJump;

    //public PlayerData(Player player, GameManager gameManager)
    //{
    //    indexCurrentScene = player.indexScene;
    //    playerHealth = player.health;
    //    playerMaxHealth = player.PlayerMaxHealth;
    //    playerExperience = player.PlayerCurrentExperience;
    //    playerLevel = player.playerCurrentLevel;
    //    playerDamage = player.damage;
    //    playerSpeed = player.speed;
    //    playerJump = player.jumpForce;

    //    playerCoin = gameManager.countCoin;
    //}

    public PlayerData(Player player, GameManager gameManager, ShopWindow shopWindow)
    {
        indexCurrentScene = player.indexScene;
        playerHealth = player.health;
        playerMaxHealth = player.PlayerMaxHealth;
        playerExperience = player.PlayerCurrentExperience;
        playerLevel = player.playerCurrentLevel;
        playerDamage = player.damage;
        playerSpeed = player.speed;
        playerJump = player.jumpForce;

        playerCoin = gameManager.countCoin;

        shopWindowDamage = shopWindow.priceDamage;
        shopWindowSpeed = shopWindow.priceSpeed;
        shopWindowJump = shopWindow.priceJump;
    }

}

