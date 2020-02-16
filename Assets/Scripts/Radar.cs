using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Radar : MonoBehaviour
{
    SphereCollider radarPing;
    public float maxSearchRadius = 100f, searchRate = 0.01f;
    private bool searching = false;
    Vector3 Direction;
    GameObject target;
    Transform mychild;

    // Start is called before the first frame update
    void Start()
    {
        radarPing = GetComponent<SphereCollider>();
        radarPing.radius = 0;
        mychild =  GetComponentInChildren<Transform>();
    }

     void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Hit");
        searching = false;
        Debug.Log(searching);
        radarPing.radius = 0;
        Direction = collision.transform.position - this.transform.position;
        mychild.forward = Direction;
       
    }


    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown("w") && searching == false)
        {
            searching = true;
        }

        if(searching == true && radarPing.radius < maxSearchRadius)
        {
            radarPing.radius += searchRate * Time.deltaTime;
        } 

        
    }


}
