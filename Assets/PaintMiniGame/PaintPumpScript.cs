// PaintPumpScript.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPumpScript : MonoBehaviour
{
    public string painttype;
    public GameObject PaintVat;
    private PaintVatScript paintVatScript;

    void Start()
    {
        if (PaintVat != null)
        {
            paintVatScript = PaintVat.GetComponent<PaintVatScript>();
        }
    }

    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("I am " + painttype);
        if (paintVatScript != null)
        {
            paintVatScript.AddColor(painttype);
        }
    }
}