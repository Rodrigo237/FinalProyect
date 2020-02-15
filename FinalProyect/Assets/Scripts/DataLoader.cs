using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataLoader : MonoBehaviour
{
    public static DataLoader instance;
    public Player currentPlayer;
    public Enemy currentEnemy;
    public string fileName;
    public string fileEnemy;
    private StreamReader sr;
    private StreamWriter sw;
    private StreamReader srEnemy;
    private StreamWriter swEnemy;
    private string jsonString;
    private string jsonStringEnemy;

    private void Awake()
    {
        instance = this;
        if(File.Exists(Application.persistentDataPath + "/" + fileName))
        {
            sr = new StreamReader(Application.persistentDataPath + "/" + fileName);
            jsonString = sr.ReadToEnd();
            sr.Close();
            currentPlayer = JsonUtility.FromJson<Player>(jsonString);
        }
        else
        {
            currentPlayer = new Player();
            currentPlayer.lives = 2;
            currentPlayer.victories = 0;
            currentPlayer.defeats = 0;
            currentPlayer.musicVolume = 0;
            currentPlayer.sfxVolume = 0;
            currentPlayer.Round = 1;
        }

        if (File.Exists(Application.persistentDataPath + "/" + fileEnemy))
        {
            srEnemy = new StreamReader(Application.persistentDataPath + "/" + fileEnemy);
            jsonStringEnemy = srEnemy.ReadToEnd();
            srEnemy.Close();
            currentEnemy = JsonUtility.FromJson<Enemy>(jsonStringEnemy);
        }
        else
        {
            currentEnemy = new Enemy();
            currentEnemy.livesEnemy = 2;
        }
    }

    public void WriteData()
    {
        sw = new StreamWriter(Application.persistentDataPath + "/" + fileName, false);
        sw.Write(JsonUtility.ToJson(currentPlayer));
        sw.Close();
    }

    public void WriteDataEnemy()
    {
        swEnemy = new StreamWriter(Application.persistentDataPath + "/" + fileEnemy, false);
        swEnemy.Write(JsonUtility.ToJson(currentEnemy));
        swEnemy.Close();
    }

}
