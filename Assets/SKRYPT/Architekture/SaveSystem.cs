using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SavePlayer (PlayerInformation Player)   
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream  = new FileStream(path, FileMode.Create);

        PlayerDataScript data = new PlayerDataScript(GameController.instance.DataStorage.PlayerInfo);

        formatter.Serialize(stream,data);
        stream.Close();

    }
    public static PlayerDataScript LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if ( File.Exists(path))
        {
          BinaryFormatter formatter = new BinaryFormatter(); 

          FileStream stream  = new FileStream(path, FileMode.Open);

          PlayerDataScript data = formatter.Deserialize(stream) as PlayerDataScript;
          stream.Close();
          return data;
        }
        else
        {
            return null;
        }
    }
}
