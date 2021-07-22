using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smashable : Target
{
    [SerializeField] private AudioClip sound;
    
    protected override void DestroyFX()
    {
        GameManager.Instance.AudioSource.PlayOneShot(sound);
    }
}
