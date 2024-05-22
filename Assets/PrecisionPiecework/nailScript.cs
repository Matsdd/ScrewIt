using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailScript : MonoBehaviour
{
    private bool nailHit = false;
    public GameObject newNail;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HitBox1"))
        {
            if (!nailHit)
            {
                Debug.Log("3 Points");
                nailHit = true;

                setHit();
            }
        }
        else if (collision.gameObject.CompareTag("HitBox2"))
        {
            if (!nailHit)
            {
                Debug.Log("2 Points");
                nailHit = true;

                setHit();
            }
        }
        else if (collision.gameObject.CompareTag("HitBox3"))
        {
            if (!nailHit)
            {
                Debug.Log("1 Point");
                nailHit = true;

                setHit();
            }
        }
        else if (collision.gameObject.CompareTag("Hammer"))
        {
            if (!nailHit)
            {
                Debug.Log("Miss");
                nailHit = true;

                setHit();
            }
        }
    }

    void setHit()
    {
        Vector2 newPosition = this.gameObject.transform.position;
        newPosition.y -= 20;
        this.gameObject.transform.position = newPosition;

        spawnNail();
    }

    void spawnNail()
    {
        Vector3 newPos = new Vector3(Random.Range(50, 700),30,0);
        Instantiate(newNail,newPos,new Quaternion(0,0,0,0));
    }

}
