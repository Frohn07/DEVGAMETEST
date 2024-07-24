using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Result : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreTMP;
    [SerializeField]
    private GameObject newRecordText;


    private void OnEnable()
    {
        if(GameParametersManager.currentScore >= GameParametersManager.recordScore)
        {
            newRecordText.SetActive(true);
        }
        else
        {
            newRecordText.SetActive(false);
        }

        scoreTMP.text = "SCORE\n" + (GameParametersManager.currentScore == 0 ? "0" : GameParametersManager.currentScore.ToString());
    }
   
}
