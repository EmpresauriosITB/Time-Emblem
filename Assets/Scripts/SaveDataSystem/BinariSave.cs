using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

public class BinariSave : MonoBehaviour
{

    private static string URL = Application.dataPath + "/Saves/";
    private static string URLPLAYERDATA = "playerData.dat";

    public static void SavePlayerData(PlayerData player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create((URL+URLPLAYERDATA));

        bf.Serialize(fileStream, player);

        fileStream.Close();
        Debug.Log("Saved");
    }

    public static PlayerData LoadPlayerData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open((URL + URLPLAYERDATA), FileMode.Open);

        PlayerData player = bf.Deserialize(fileStream) as PlayerData;

        fileStream.Close();

        return player;
    }
}
