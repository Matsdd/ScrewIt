using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailScript : MonoBehaviour
{
    private bool nailHit = false;
    public GameObject newNail;
    private static int num = 1;
    private bool crooked = false;

    private void Start()
    {
        num++;
        this.gameObject.name = "Nail" + num;
        Debug.Log(num);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HitBox1"))
        {
            if (!nailHit && HammerScript.getSlam)
            {
                GameScript.time += 2;
                GameScript.hits++;
                nailHit = true;
                HammerScript.getSlam = false;

                setHit();
            }
        }
        else if (collision.gameObject.CompareTag("HitBox2"))
        {
            if (!nailHit && HammerScript.getSlam)
            {
                GameScript.time += 1;
                GameScript.hits++;
                nailHit = true;
                HammerScript.getSlam = false;

                setHit();
            }
        }
        else if (collision.gameObject.CompareTag("HitBox3"))
        {
            if (!nailHit && HammerScript.getSlam)
            {
                GameScript.hits++;
                nailHit = true;
                HammerScript.getSlam = false;

                setHit();
            }
        }
        else if (collision.gameObject.CompareTag("HitBox4"))
        {
            if (!nailHit && HammerScript.getSlam)
            {
                GameScript.time -= 1;
                nailHit = true;
                HammerScript.getSlam = false;

                setCrooked();
            }
        }
        else if (collision.gameObject.CompareTag("HitBox5"))
        {
            if (crooked && HammerScript.flipped)
            {
                setPosition(100);
                spawnNail();
            }
        }
    }

    void setHit()
    {
        setPosition(20);

        spawnNail();
    }

    void setPosition(int ypos)
    {
        Vector2 newPosition = this.gameObject.transform.position;
        newPosition.y -= ypos;
        this.gameObject.transform.position = newPosition;
    }

    void setCrooked()
    {
        int abcdefghijklmnopqrstuvwxyz = Random.Range(0, 1);
        if (abcdefghijklmnopqrstuvwxyz == 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -30);
        }
        crooked = true;
    }

    void spawnNail()
    {
        Vector3 newPos = new Vector3(Random.Range(50, 700),30,0);
        Instantiate(newNail,newPos,new Quaternion(0,0,0,0));
    }

    private void FixedUpdate()
    {
        if (this.gameObject.name == "Nail"+(num-8))
        {
            Destroy(this.gameObject);
        }
    }

}
