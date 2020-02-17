using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public energy generator;
    public bool[] abilities = new bool[13];
    public GameObject[] icons = new GameObject[13];
    public float[] powers = new float[13];
    private float sum = 0;

    public void ToggleAbility(int index)
    {
        abilities[index] = !abilities[index];
        icons[index].SetActive(abilities[index]);
        for(int i = 0; i < powers.Length; i++)
        {
            if (abilities[i])
            {
                sum += powers[i];
            }
        }
        generator.setDecayRate(sum);
        sum = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < icons.Length; i++)
        {
            icons[i].SetActive(abilities[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
