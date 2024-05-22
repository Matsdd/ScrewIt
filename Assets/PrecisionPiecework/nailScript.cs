using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailScript : MonoBehaviour
{
    private bool nailHit = false;
    public GameObject newNail;
    private static int num = 1;

    private void Start()
    {
        this.gameObject.name = "Nail" + num;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HitBox1"))
        {
            if (!nailHit)
            {
                GameScript.time += 3;
                GameScript.hits++;
                nailHit = true;

                setHit();
            }
        }
        else if (collision.gameObject.CompareTag("HitBox2"))
        {
            if (!nailHit)
            {
                GameScript.time += 1;
                GameScript.hits++;
                nailHit = true;

                setHit();
            }
        }
        else if (collision.gameObject.CompareTag("HitBox3"))
        {
            if (!nailHit)
            {
                GameScript.hits++;
                nailHit = true;

                setHit();
            }
        }
        else if (collision.gameObject.CompareTag("HitBox4"))
        {
            if (!nailHit)
            {
                GameScript.time -= 1;
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
        num++;

        spawnNail();
    }

    void spawnNail()
    {
        Vector3 newPos = new Vector3(Random.Range(50, 700),30,0);
        Instantiate(newNail,newPos,new Quaternion(0,0,0,0));
    }

    private void FixedUpdate()
    {
        if (this.gameObject.name == "Nail"+(num-5))
        {
            Destroy(this.gameObject);
        }
    }

}
