using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectdataLoad : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameManager gameManager;

    //public void SavePlayer()
    //{
    //    SaveSystem.SavePlayer(Player.PlayerInstance);

    //    Debug.Log("Save");
    //}

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(Player.PlayerInstance, GameManager.GameManagerInstance);

        Debug.Log("Save");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        player.health = data.playerHealth;

        player.PlayerMaxHealth = data.playerMaxHealth;

        player.PlayerCurrentExperience = data.playerExperience;

        player.playerCurrentLevel = data.playerLevel;

        gameManager.countCoin = data.playerCoin;

        Debug.Log("Load");
    }

    public void ResetPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        player.health = 20;

        player.PlayerMaxHealth = 20;

        player.PlayerCurrentExperience = 0;

        player.playerCurrentLevel = 1;

        gameManager.countCoin = 0;

        Debug.Log("ResetPlayerData");
    }
}
