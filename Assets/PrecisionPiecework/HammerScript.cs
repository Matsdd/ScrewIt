using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public GameObject hammer;
    public Rigidbody2D hammerRb;

    private bool setPosition = false;
    private float charge = 0;
    public static bool getSlam = false;
    public static bool flipped = false;
    private float currentSlamCharge = 180;


    private void OnMouseDown()
    {
        if (GameScript.time > 0)
        {
            setPosition = true;
            hammer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            charge = 0;
            currentSlamCharge = 180;
            hammerRb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            GameScript.gameStarted = true;
        }
    }

    private void OnMouseUp()
    {
        setPosition = false;
    }

    private void Update()
    {
        if (setPosition && GameScript.time > 0)
        {
            hammerRb.MovePosition(Input.mousePosition);
            hammerRb.Sleep();
        }
        else
        {
            hammerRb.WakeUp();
        }

        if (Input.GetKeyUp(KeyCode.Space) && charge < 0)
        {
            getSlam = true;
            currentSlamCharge = charge;
        }

        if (this.gameObject.transform.position.y < -100)
        {
            this.gameObject.transform.position = new Vector2(366,180);
        }

        if (Input.GetKey(KeyCode.LeftShift) && setPosition)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            flipped = true;
        }
        else
        {
            flipped = false;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && setPosition && charge > -70 && !getSlam)
        {
            charge -= charge > 0 ? 5 : 3.5f;
            hammer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, charge));
        }

        if (charge > (currentSlamCharge * -1.5))
        {
            getSlam = false;
        }

        if (getSlam)
        {
            charge -= currentSlamCharge/6;
            hammer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, charge));
        }
    }
}
