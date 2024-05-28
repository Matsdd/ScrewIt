using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setHighScoreTextScript : MonoBehaviour
{
    public TMP_Text txt1;
    public TMP_Text txt2;
    public TMP_Text txt3;
    public TMP_Text txt4;

    private void Start()
    {
        txt1.text = "Highscore = " + PlayerPrefs.GetInt("Highscore");
    }
}
