using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_GamePlayPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreTMP;


    private void Update()
    {
        scoreTMP.text = "SCORE\n" + (GameParametersManager.currentScore == 0 ? "0" : GameParametersManager.currentScore.ToString());
    }
}
