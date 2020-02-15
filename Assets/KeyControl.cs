using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyControl : MonoBehaviour
{
    public movement move;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey("w"))
      {
      move.MoveUp();
      }
      if(Input.GetKey("s"))
      {
      move.MoveDown();
      }
      if(Input.GetKey("a"))
      {
      move.MoveLeft();
      }
      if(Input.GetKey("d")){
      move.MoveRight();
      }
      if(Input.GetKeyDown(KeyCode.Space))
      {
      move.jump();
      }
    }
}
