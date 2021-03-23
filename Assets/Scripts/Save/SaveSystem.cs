﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Player(SavePlayerData game)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/playerInfo.csv";
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        DataOfPlayer data = new DataOfPlayer(game);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static DataOfPlayer Load()
    {
        string filePath = Application.persistentDataPath + "/playerInfo.csv";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            DataOfPlayer data = formatter.Deserialize(stream) as DataOfPlayer;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("path doesnt exist" + filePath);
            return null;
        }
    }
}
