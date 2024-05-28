using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setHighScoreTextScript : MonoBehaviour
{
    //hammer
    public TMP_Text txt1;
    //sorteer
    public TMP_Text txt2;
    //kleuren
    public TMP_Text txt3;
    //boenen
    public TMP_Text txt4;
    //total
    public TMP_Text txt5;

    private void Start()
    {
        txt1.text = "Highscore = " + PlayerPrefs.GetInt("Highscore");
    }
}
