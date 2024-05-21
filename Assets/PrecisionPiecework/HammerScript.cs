using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public GameObject hammer;
    public Rigidbody2D hammerRb;

    private bool setPosition = false;
    private float charge = 0;
    private bool getSlam = false;
    private float currentSlamCharge = 0;

    private void OnMouseDown()
    {
        setPosition = true;
        hammer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    private void OnMouseUp()
    {
        setPosition = false;
    }

    private void Update()
    {
        if (setPosition)
        {
            hammer.transform.position = Input.mousePosition;
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
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && setPosition && charge > -70)
        {
            Debug.Log(charge);
            if (charge > 0)
            {
                charge -= 2.5f;
            }
            else
            {
                charge -= 0.5f;
            }
            hammer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, charge));
        }


        if (charge > 180)
        {
            getSlam = false;
        }

        if (getSlam)
        {
            charge -= currentSlamCharge/5;
            hammer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, charge));
        }
    }
}
