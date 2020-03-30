﻿using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SavePlayer (Player Player)   
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream  = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(Player);

        formatter.Serialize(stream,data);
        stream.Close();

    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if ( File.Exists(path))
        {
          BinaryFormatter formatter = new BinaryFormatter(); 

          FileStream stream  = new FileStream(path, FileMode.Open);

          PlayerData data = formatter.Deserialize(stream) as PlayerData;
          stream.Close();
          return data;
        }
        else
        {
            return null;
        }
    }
}