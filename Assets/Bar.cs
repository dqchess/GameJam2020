using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxEnergy (float energy)
    {
      slider.maxValue = energy;
    }

    public void SetEnergy(float energy)
    {

      slider.value = energy;
      Debug.Log("slider value=" + slider.value);
    }
}
