using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text recordScoreTMP;

    private void OnEnable()
    {
        recordScoreTMP.text = "RECORD SCORE\n" + GameParametersManager.recordScore.ToString();
    }

    public void StartPlay()
    {
        SceneManager.LoadScene("Game");
    }

}
