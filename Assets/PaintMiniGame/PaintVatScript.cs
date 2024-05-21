using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintVatScript : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Changecolor(string color)
    {
        Debug.Log("the vat is now " + color);
        if (color == "Blue")
        {
            _spriteRenderer.color = Color.blue;
        }
        if (color == "Red")
        {
            _spriteRenderer.color = Color.red;
        }
        if (color == "Yellow")
        {
            _spriteRenderer.color = Color.yellow;
        }
    }
}
