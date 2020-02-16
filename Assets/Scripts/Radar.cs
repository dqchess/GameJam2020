using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Radar : MonoBehaviour
{
    private IEnumerator coroutine;
    SphereCollider radarPing;
    public float maxSearchRadius = 100f, searchRate = 0.01f;
    private bool searching = false, found = false;
    Vector3 Direction;
    GameObject target, mychild;

    // Start is called before the first frame update
    void Start()
    {
        radarPing = GetComponent<SphereCollider>();
        radarPing.radius = 0;
        mychild =  GetComponentInChildren<MeshRenderer>().gameObject;
        mychild.SetActive(false);
    }

     void OnTriggerEnter(Collider collision)
    {
        found = true;
        searching = false;
        transform.position = transform.parent.position;
        radarPing.radius = 0;
        target = collision.gameObject;
        mychild.SetActive(true);
        mychild.transform.forward = -Direction;
        StartCoroutine(RemoveRadar()); 
    }

    IEnumerator RemoveRadar()
    {
        yield return new WaitForSecondsRealtime(3);
        mychild.SetActive(false);
        target = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown("w") && searching == false)
        {
            searching = true;
            found = false;
        }

        if(searching == true && radarPing.radius < maxSearchRadius)
        {
            radarPing.radius += searchRate * Time.deltaTime;
        }

        if (found)
        {
            Direction = target.transform.position - this.transform.position;
            mychild.transform.forward = -Direction;
        }
    }


}
