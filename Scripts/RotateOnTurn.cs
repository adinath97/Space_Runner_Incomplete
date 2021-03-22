using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnTurn : MonoBehaviour
{
    Quaternion targetAngle_Neg30 = Quaternion.Euler(0, 0, -30);
    Quaternion targetAngle_0 = Quaternion.Euler(0, 0, 0);
    Quaternion currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = targetAngle_0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("TURN!");
            ChangeCurrentAngle();
        }

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentAngle, .1f);
    }

    private void ChangeCurrentAngle()
    {
        if(currentAngle.eulerAngles.z == targetAngle_0.eulerAngles.z)
        {
            currentAngle = targetAngle_Neg30;
        }
        else
        {
            currentAngle = targetAngle_0;
        }
    }
}
