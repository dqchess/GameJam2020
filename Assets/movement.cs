using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //
    // Rigidbody rb;
    // public float speed = 1f;
    // public float yForce = 200f;
    // public float xForce = 150f;
    // public float zForce = 150f;
    // bool onGround = true;
    // public float jumpTime = 1f;
    public float movespeed = 30f;
    public float RotateSpeed = 60f;

    public bool isForward;
    public bool isBackward;
    public bool isLeft;
    public bool isRight;

    public void ActivateMovementAbility(MovementState type, bool value)
    {
        switch (type)
        {
            case MovementState.Forward:
                isForward = value;
                break;
            case MovementState.Backward:
                Debug.Log(value);
                isBackward = value;
                break;
            case MovementState.Left:
                isLeft = value;
                break;
            case MovementState.Right:
                isRight = value;
                break;
        }
    }

    //Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0f && isRight)
            transform.Rotate(0f, Input.GetAxis("Horizontal") * Time.deltaTime * RotateSpeed, 0f);
        if (Input.GetAxis("Horizontal") < 0f && isLeft)
            transform.Rotate(0f, Input.GetAxis("Horizontal") * Time.deltaTime * RotateSpeed, 0f);

        if (Input.GetAxis("Vertical") > 0f && isForward)
            transform.Translate(Input.GetAxis("Vertical") * Time.deltaTime * movespeed, 0f, 0f);
        if (Input.GetAxis("Vertical") < 0f && isBackward)
            transform.Translate(Input.GetAxis("Vertical") * Time.deltaTime * movespeed, 0f, 0f);
    }

    // public void MoveUp()
    // {
    //   rb.AddForce(0,0,zForce*Time.deltaTime*speed,ForceMode.VelocityChange);
    // }
    // public void MoveDown()
    // {
    //   rb.AddForce(0,0,-zForce*Time.deltaTime*speed,ForceMode.VelocityChange);
    // }
    //
    //
    // public void MoveLeft()
    // {
    //   rb.AddForce(-xForce*Time.deltaTime*speed,0,0,ForceMode.VelocityChange);
    // }
    // public void MoveRight()
    // {
    //   rb.AddForce(xForce*Time.deltaTime*speed,0,0,ForceMode.VelocityChange);
    // }
    //
    //
    // public void jump()
    // {
    //   if(onGround)
    //   {
    //   rb.AddForce(0,yForce*.01f,0,ForceMode.VelocityChange);
    //   onGround = false;
    //   Invoke("jumpReSet", jumpTime);
    //   }
    // }
    //
    // void jumpReSet()
    // {
    //   onGround = true;
    // }


}
