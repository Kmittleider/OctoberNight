using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMouseClick : MonoBehaviour
{
    public Light lightToSwitch = null;
    
    void Start()
    {
        lightToSwitch.enabled = false;
    }

    void OnMouseDown()
    {
        lightToSwitch.enabled = !lightToSwitch.enabled;
    }

}
