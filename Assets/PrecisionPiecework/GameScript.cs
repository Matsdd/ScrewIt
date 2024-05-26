using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{
    public TMP_Text txt1;
    public TMP_Text txt2;
    public TMP_Text txt3;
    public static float time = 30;
    public static int hits = 0;
    private float alphatxt = 255;
    private float ypostxt = 300;

    private void FixedUpdate()
    {
        time -= (1/60);
        txt1.text = Mathf.Round(time) + " sec";

        txt2.text = hits + " hits";

        alphatxt = Mathf.Clamp(alphatxt - 0.004f, 0, 1);
        txt3.color = new Color(1f, 1f, 1f, alphatxt);
        ypostxt += 0.3f;
        txt3.transform.position = new Vector2(366,ypostxt);
    }
}
