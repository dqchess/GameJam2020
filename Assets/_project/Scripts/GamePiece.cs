using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamePiece : MonoBehaviour
{
    private Vector2 mouseOffset = Vector2.zero;

    private bool rotating = false;

    private bool dragging = false;

    private Vector2 mouseWorldPosition = Vector2.zero;

    private Quaternion currentRotation = Quaternion.identity;
    private Quaternion finalRotation = Quaternion.identity;

    private float rotationTimer = 0f;

    private float rotationSpeed = 16f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mouseWorldPosition);
        //if (UnityEngine.Input.GetMouseButton(0) && !dragging)
        //{


        //    RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);

        //    if (hit)
        //    {
        //        bool collidedWithGamePiece = hit.collider.CompareTag("Piece");

        //        Debug.Log("hit: " + collidedWithGamePiece);

        //        if (collidedWithGamePiece)
        //        {
        //            //currentMouseOffset = (Vector2)_cupTransform.position - mouseWorldPosition;

        //            dragging = true;


        //        }
        //    }
        //}
        //if (UnityEngine.Input.GetMouseButtonUp(0))
        //{


        //    dragging = false;
        //}


        //Debug.Log(dragging);

        if (dragging)
        {
            if(Input.GetMouseButtonDown(1))
            {
                if(!rotating)
                {
                    currentRotation = transform.rotation; //transform.rotation
                    finalRotation = Quaternion.Euler(0f, 0f, 90f) * transform.rotation; //transform.rotation

                    rotating = true;
                }
            }

            transform.position = mouseWorldPosition;// - mouseOffset;

            Debug.Log(transform.position);
        }

        if(rotating)
        {
            if(rotationTimer < 1f)
            {
                transform.rotation = Quaternion.Lerp(currentRotation, finalRotation, rotationTimer);
                rotationTimer += (Time.deltaTime * rotationSpeed);
            }
            else
            {
                transform.rotation = finalRotation;
                rotationTimer = 0f;
                rotating = false;
            }
        }

    }
    private void OnMouseDown()
    {
        //Debug.Log("DOWN");
        mouseOffset = mouseWorldPosition - (Vector2) transform.position;
        dragging = true;
    }

    private void OnMouseOver()
    {
       // Debug.Log("OVER");


    }

    private void OnMouseUp()
    {
        //Debug.Log("");
        dragging = false;
    }

}
