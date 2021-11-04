using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light lightToSwitch = null;

    public void Start()
    {
        lightToSwitch.enabled = false;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        lightToSwitch.enabled = true;
    }

    public void OnTriggerExit(Collider other)
    {
        lightToSwitch.enabled = false;
    }
}
