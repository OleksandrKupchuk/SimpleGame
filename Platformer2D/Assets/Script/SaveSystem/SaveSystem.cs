using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    //public static void SavePlayer(Player player, GameManager gameManager)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();

    //    string pathSave = Application.persistentDataPath + "/player.date";

    //    FileStream stream = new FileStream(pathSave, FileMode.Create);

    //    PlayerData data = new PlayerData(player, gameManager);

    //    formatter.Serialize(stream, data);

    //    stream.Close();
    //}

    public static void SavePlayer(Player player, GameManager gameManager, ShopWindow shopWindow)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string pathSave = Application.persistentDataPath + "/player.date";

        FileStream stream = new FileStream(pathSave, FileMode.Create);

        PlayerData data = new PlayerData(player, gameManager, shopWindow);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string pathSave = Application.persistentDataPath + "/player.date";

        if (File.Exists(pathSave))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(pathSave, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }

        else
        {
            Debug.LogError("Save file not found in " + pathSave);
            return null;
        }
    }
}
