using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeBox : MonoBehaviour
{
    [Tooltip("Should be coded better but it's 2AM")]
    public Mesh[] Boxes;

    // Start is called before the first frame update
    void Start()
    {
        Mesh newBox = Boxes[Random.Range(0, Boxes.Length-1)];
        GetComponent<MeshFilter>().mesh = newBox;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
