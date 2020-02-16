using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //
    // Rigidbody rb;
    // public float speed = 1f;
    // public float yForce = 200f;
    // public float xForce = 150f;
    // public float zForce = 150f;
    // bool onGround = true;
    // public float jumpTime = 1f;
<<<<<<< HEAD
    public float movespeed = 30f;
    public float RotateSpeed = 60f;
=======
    public float movespeed;
    public float RotateSpeed;
>>>>>>> master

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
=======
      movespeed = 30f;
      RotateSpeed = 60f;
>>>>>>> master

    }

    //Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
     transform.Translate(Input.GetAxis("Vertical") * Time.deltaTime * movespeed,0f,0f);
=======
     transform.Translate(0f,0f,Input.GetAxis("Vertical") * Time.deltaTime * movespeed);
>>>>>>> master
     transform.Rotate(0f,Input.GetAxis("Horizontal") * Time.deltaTime * RotateSpeed,0f);
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
