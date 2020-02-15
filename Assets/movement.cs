using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 1f;
    public float yForce = 200f;
    public float xForce = 150f;
    public float zForce = 150f;
    bool onGround = true;
    public float jumpTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    void Update()
    {
      // if(Input.GetKey("w"))
      // {
      //  MoveUp();
      // }
    }

    public void MoveUp()
    {
      rb.AddForce(0,0,zForce*Time.deltaTime*speed,ForceMode.VelocityChange);
    }
    public void MoveDown()
    {
      rb.AddForce(0,0,-zForce*Time.deltaTime*speed,ForceMode.VelocityChange);
    }


    public void MoveLeft()
    {
      rb.AddForce(-xForce*Time.deltaTime*speed,0,0,ForceMode.VelocityChange);
    }
    public void MoveRight()
    {
      rb.AddForce(xForce*Time.deltaTime*speed,0,0,ForceMode.VelocityChange);
    }


    public void jump()
    {
      if(onGround)
      {
      rb.AddForce(0,yForce*.01f,0,ForceMode.VelocityChange);
      onGround = false;
      Invoke("jumpReSet", jumpTime);
      }
    }

    void jumpReSet()
    {
      onGround = true;
    }


}
