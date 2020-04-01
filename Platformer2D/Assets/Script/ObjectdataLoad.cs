using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectdataLoad : MonoBehaviour
{
    [SerializeField] Player player;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(Player.PlayerInstance);

        Debug.Log("Save");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        player.health = data.playerHealth;

        player.PlayerMaxHealth = data.playerMaxHealth;

        player.CurrentExperience = data.playerExperience;

        //Player.PlayerInstance.health = data.playerHealth;

        //Player.PlayerInstance.PlayerMaxHealth = data.playerMaxHealth;

        //Player.PlayerInstance.CurrentExperience = data.playerExperience;

        Debug.Log("Load");
    }
}
