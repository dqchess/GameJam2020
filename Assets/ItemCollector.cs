using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    int numberOfDiaper;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.tag == "item")
      {
        Destroy(other.gameObject);
        numberOfDiaper++;
        Debug.Log("numberOfDiaper=" + numberOfDiaper);
      }
    }

}
