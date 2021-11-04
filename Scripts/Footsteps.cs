using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public CheckIfGrounded checkIfGrounded;
    public CheckTerrainTexture checkTerrainTexture;
    public AudioSource audioSource;
    public AudioClip[] concreteFootsteps;
    public AudioClip[] grassFootstep;
    AudioClip previousClip;

    CharacterController character;
    float currentSpeed;
    bool walking;
    float distanceCovered;
    public float modifier = 0.5f;
    float airTime;

    void Start()
    {
        character = gameObject.GetComponent<CharacterController>();
    }

    float GetPlayerSpeed()
    {
        float speed = character.velocity.magnitude;
        return speed;
    }

    void Update()
    {
        currentSpeed = GetPlayerSpeed();
        walking = CheckIfWalking();
        PlaySoundIfFalling();

        if (walking)
        {
            distanceCovered += (currentSpeed * Time.deltaTime) * modifier;
            if (distanceCovered > 1)
            {
                TriggerNextClip();
                distanceCovered = 0;
            }
        }
    }

    bool CheckIfWalking()
    {
        if (currentSpeed > 0 && checkIfGrounded.isGrounded)
        {
            return true;
        } else
        {
            return false;
        }
    }

    AudioClip GetClipFromArray(AudioClip[] clipArray)
    {
        int attempts = 3;
        AudioClip selectedClip = clipArray[Random.Range(0, clipArray.Length - 1)];

        while (selectedClip == previousClip && attempts > 0)
        {
            selectedClip = clipArray[Random.Range(0, clipArray.Length - 1)];
            attempts--;
        }

        previousClip = selectedClip;
        return selectedClip;
    }

    public void TriggerNextClip()
    {
        if (checkIfGrounded.isOnTerrain)
        {
            checkTerrainTexture.GetTerrainTexture();

            if (checkTerrainTexture.textureValues[0] > 0)
            {
                audioSource.PlayOneShot(GetClipFromArray(grassFootstep), checkTerrainTexture.textureValues[0]);
            }
            if (checkTerrainTexture.textureValues[1] > 0)
            {
                audioSource.PlayOneShot(GetClipFromArray(concreteFootsteps), checkTerrainTexture.textureValues[1]);
            }
        }
    }

    void PlaySoundIfFalling()
    {
        if (!checkIfGrounded.isGrounded)
        {
            airTime += Time.deltaTime;
        } else
        {
            if (airTime > 0.25f)
            {
                TriggerNextClip();
                airTime = 0;
            }
        }
    }
}
