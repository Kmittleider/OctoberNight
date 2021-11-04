using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMouseClick : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        source.Play();
    }
}
