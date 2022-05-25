using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.IO;

/// <summary>
/// Has utility methods that store player game instance data into the player data list
/// and retrieves player game instance data from the player data list
/// it only receives and gives data.
/// </summary>
public static class DataManager
{
    public static List<string> PlayerData = new List<string>();

    public static void InitData()
    {
        PlayerData = BinaryUtility.LoadPlayerData();
    }
    public static void CreateNewPlayer(GameData newPlayerData)
    {
        //convert incoming playerData to string
        var newPlayerJson = JsonUtility.ToJson(newPlayerData);
        //get the list of players from the file

        //add this new player to this list
        PlayerData.Add(newPlayerJson);

        foreach (var item in PlayerData)
        {
            Debug.Log(item);
        }
        //re-serialize the list.
        SavePlayerData(PlayerData);
    }

    public static List<GameData> GetAllPlayers()
    {
        List<GameData> retrievedGameDataList = new List<GameData>();
        GameData loadData;
        var retrievedData = BinaryUtility.LoadPlayerData();
        foreach (var data in retrievedData)
        {
            loadData = JsonUtility.FromJson<GameData>(data);
            retrievedGameDataList.Add(loadData);
        }
        return retrievedGameDataList;
    }

    private static void SavePlayerData(List<string> currentPlayerData)
    {
        //convert each item in the incoming list to string
        //send it off to the Binary Utility as a list of string.
        BinaryUtility.SavePlayerList(currentPlayerData);
    }

    #region Utility Class
    private class BinaryUtility
    {
        public static void SavePlayerList(List<string> playerData)
        {
            var listString = JsonConvert.SerializeObject(playerData);


            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/playerData.data";
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, listString);

            stream.Close();
        }

        public static List<string> LoadPlayerData()
        {
            string path = Application.persistentDataPath + "/playerData.data";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                var retrievedData = (string)formatter.Deserialize(stream);
                var returnData = JsonConvert.DeserializeObject<List<string>>(retrievedData);
               
                return returnData;
            }
            else
            {
                Debug.LogError("Saved data not found in " + path);
                return null;
            }

        }
    } 
    #endregion
}
