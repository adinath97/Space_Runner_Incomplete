using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeedHorizontal;
    [SerializeField] float moveSpeedVertical;
    [SerializeField] float speed = 5;
    public Rigidbody myRigidbody;
    bool hitRightWall, hitLeftWall, hitTopWall, hitBottomWall;
    float horizontalInput, verticalInput, tempMoveSpeedHorizontal, tempMoveSpeedVertical;
    float yMin, yMax;
    [SerializeField] float tilt = 50;
    Vector3 verticalMove, horizontalMove, moveForward, updatedVerticalMove;
    [SerializeField] Transform child;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody>();
        //yMax = 17f;
        //yMin = 5f;
        hitTopWall = false;

    }

    private void FixedUpdate()
    {

        Move();
        CheckBoundaries();
        PlayerRotation();

        if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            //freeze y movement
            myRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            myRigidbody.constraints = RigidbodyConstraints.None;
        }
    }

    void PlayerRotation()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput * moveSpeedHorizontal, verticalInput * moveSpeedVertical, 0f);

        myRigidbody.rotation = Quaternion.Euler(0, 0, movement.x * -tilt * Time.fixedDeltaTime);
    }

    private void CheckBoundaries()
    {
        CheckRightWall();
        CheckLeftWall();
        CheckBottomWall();
        CheckTopWall();
    }

    private void CheckRightWall()
    {
        //raycast to detect wall on right
        var ray = new Ray(this.transform.position, this.transform.right);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 4f))
        {
            hitRightWall = true;
            Debug.Log("NOT A TEST??");
        }
        if(hitRightWall)
        {
            //check if you're not close to the wall. if so, you can move right again
            if(!Physics.Raycast(ray, out hitInfo, 4f))
            {
                hitRightWall = false;
            }
        }
    }

    private void CheckLeftWall()
    {
        //raycast to detect wall on right
        var ray = new Ray(this.transform.position, -this.transform.right);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 4f))
        {
            hitLeftWall = true;
        }
        if (hitLeftWall)
        {
            //check if you're not close to the wall. if so, you can move right again
            if (!Physics.Raycast(ray, out hitInfo, 4f))
            {
                hitLeftWall = false;
            }
        }
    }

    private void CheckBottomWall()
    {
        //raycast to detect wall on right
        var ray = new Ray(this.transform.position, -this.transform.up);
        RaycastHit hitInfo;
        //Debug.DrawRay(this.transform.position, -this.transform.up * 1.5f, Color.green);
        if (Physics.Raycast(ray, out hitInfo, 4f))
        {

            if (hitInfo.transform.tag == "BottomWall")
            {
                Debug.Log("HIT IT!!!!");
                hitBottomWall = true;
            }
        }
        if (hitBottomWall)
        {
            //check if you're not close to the wall. if so, you can move right again
            if (!Physics.Raycast(ray, out hitInfo, 4f))
            {
                hitBottomWall = false;
                Debug.Log("IT'S OFF!!!!");
            }
        }
    }

    private void CheckTopWall()
    {
        //raycast to detect wall on right
        var ray = new Ray(this.transform.position, this.transform.up);
        Debug.DrawRay(this.transform.position, this.transform.up * 3f, Color.green);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 3f))
        {
            if(hitInfo.transform.tag == "Test")
            {
                hitTopWall = true;
                Debug.Log("IT IS TEST");
            }
            
        }
        if (hitTopWall)
        {
            //check if you're not close to the wall. if so, you can move right again
            if (!Physics.Raycast(ray, out hitInfo, 3f))
            {
                hitTopWall = false;
            }
        }
    }

    private void Move()
    {
        moveForward = transform.forward * speed * Time.fixedDeltaTime;
        HorizontalMovement();
        if (this.transform.position.y < 18f && this.transform.position.y > 5f)
        {
            VerticalMovement();
        }
        else
        {
            verticalMove = Vector3.zero;
        }
        myRigidbody.MovePosition(myRigidbody.position + moveForward + horizontalMove + verticalMove);
    }

    private void VerticalMovement()
    {
        //up
        if (Input.GetKey(KeyCode.UpArrow) && !hitTopWall)
        {
            verticalMove = transform.up * moveSpeedVertical * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) && hitTopWall)
        {
            verticalMove = Vector3.zero;
        }
        //down
        if (Input.GetKey(KeyCode.DownArrow) && !hitBottomWall)
        {
            verticalMove = -transform.up * moveSpeedVertical * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && hitBottomWall)
        {
            verticalMove = Vector3.zero;
        }
        if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            verticalMove = Vector3.zero;
        }
    }

    private void HorizontalMovement()
    {
        //right
        if (Input.GetKey(KeyCode.RightArrow) && !hitRightWall)
        {
            horizontalMove = transform.right * moveSpeedHorizontal * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow) && hitRightWall)
        {
            horizontalMove = Vector3.zero;
        }
        //left
        if (Input.GetKey(KeyCode.LeftArrow) && !hitLeftWall)
        {
            horizontalMove = -transform.right * moveSpeedHorizontal * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && hitLeftWall)
        {
            horizontalMove = Vector3.zero;
        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMove = Vector3.zero;
        }
    }
}
