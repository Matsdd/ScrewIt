using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HitBox1"))
        {
            Debug.Log("3 Points");
        }
        else if (collision.gameObject.CompareTag("HitBox2"))
        {
            Debug.Log("2 Points");
        }
        else if (collision.gameObject.CompareTag("HitBox3"))
        {
            Debug.Log("1 Point");
        }
        else if (collision.gameObject.CompareTag("Hammer"))
        {
            Debug.Log("Miss");
        }
    }

}
