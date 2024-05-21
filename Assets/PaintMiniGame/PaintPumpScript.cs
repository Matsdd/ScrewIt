using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class PaintPumpScript : MonoBehaviour
{

    public string painttype;
    public GameObject PaintVat;

    private PaintVatScript paintVatScript;

    // Start is called before the first frame update
    void Start()
    {
        if (PaintVat != null)
        {
            paintVatScript = PaintVat.GetComponent<PaintVatScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("i am " + painttype);
        if (paintVatScript != null)
        {
            paintVatScript.Changecolor(painttype);
        }

    }
}
