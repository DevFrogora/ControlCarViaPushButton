using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLight : MonoBehaviour
{
    public Light light;
    
    public void SetLightOn()
    {
        light.enabled = true;
    }

    public void SetLightOff()
    {
        light.enabled = false;
    }
}
