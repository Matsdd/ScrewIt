using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{
    public TMP_Text txt1;
    public TMP_Text txt2;
    public TMP_Text txt3;
    public static float time;
    public static int hits;
    private float alphatxt = 255;
    private float ypostxt = 300;
    public Canvas canvas;
    public TMP_Text scoreTxt;
    private static float highScore;
    public static bool gameStarted;


    private void Start()
    {
        canvas.enabled = false;
        hits = 0;
        time = 20;
        gameStarted = false;
        highScore = PlayerPrefs.GetInt("Highscore");
    }

    private void FixedUpdate()
    {
        if (time > 0 && gameStarted)
        {
            time -= 0.016666667f;
            txt1.text = Mathf.Round(time) + " Sec";
        }

        txt2.text = hits + " Hits";

        alphatxt = Mathf.Clamp(alphatxt - 0.004f, 0, 1);
        txt3.color = new Color(1f, 1f, 1f, alphatxt);
        ypostxt += 0.3f;
        txt3.transform.position = new Vector2(366,ypostxt);

        if (time <= 0)
        {
            youLose();
        }
    }

    void youLose()
    {
        canvas.enabled = true;
        if (hits > highScore)
        {
            highScore = hits;
            PlayerPrefs.SetInt("Highscore", hits);
        }
        PlayerPrefs.SetInt("TotalScore", (hits + PlayerPrefs.GetInt("TotalScore")));
        scoreTxt.text = "Final score: "+hits+"\nHigh score: "+highScore;
    }
}
