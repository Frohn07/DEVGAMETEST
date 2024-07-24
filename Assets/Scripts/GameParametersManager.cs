using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameParametersManager : MonoBehaviour
{
    public static int currentScore;
    public static int recordScore
    {
        get
        {
            if (!PlayerPrefs.HasKey("recordScoreKey"))
            {
                PlayerPrefs.SetInt("recordScoreKey", 0);
            }

            return PlayerPrefs.GetInt("recordScoreKey");
        }
        set
        {
            PlayerPrefs.SetInt("recordScoreKey", value);
        }
    }


    private static string saveFilePath;

    private void Start()
    {
        currentScore = 0;


    }

    public static void CheckAndSaveRecord()
    {
        if(currentScore > recordScore)
        {
            recordScore = currentScore;
        }
    }




}

public class PlayerData
{
    public int recordScore;
}