using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectdataLoad : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ShopWindow shopWindow;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(Player.PlayerInstance, GameManager.GameManagerInstance, ShopWindow.Instance);

        Debug.Log("Save");
    }

    public void LoadPlayer()
    {
        if (player.indexScene != 0)
        {
            PlayerData data = SaveSystem.LoadPlayer();

            player.health = data.playerHealth;
            player.PlayerMaxHealth = data.playerMaxHealth;
            player.PlayerCurrentExperience = data.playerExperience;
            player.PlayerMaxExperienceInCurrentLevel = data.playerMaxExperience;
            player.playerCurrentLevel = data.playerLevel;
            player.damage = data.playerDamage;
            player.speed = data.playerSpeed;
            player.jumpForce = data.playerJump;

            gameManager.countCoin = data.playerCoin;

            shopWindow.priceDamage = data.shopWindowDamage;
            shopWindow.priceSpeed = data.shopWindowSpeed;
            shopWindow.priceJump = data.shopWindowJump;

            player.indexScene = data.indexCurrentScene;
        }

        else
        {
            Debug.Log("Завантажень немає!");
        }
    }

    public void DefaultPlayerData()
    {
        player.health = 20;
        player.PlayerMaxHealth = 20;
        player.PlayerCurrentExperience = 0;
        player.PlayerMaxExperienceInCurrentLevel = 10;
        player.playerCurrentLevel = 1;
        player.damage = 5;
        player.speed = 5;
        player.jumpForce = 10;

        gameManager.InitializationCoin();

        shopWindow.InitializationPrice();

        SceneManager.LoadScene(1);

        Debug.Log("ResetPlayerData");
    }
}
