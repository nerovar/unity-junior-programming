using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Poppable : Target
{
    [SerializeField] private AudioClip sound;

    protected override void DestroyFX()
    {
        GameManager.Instance.AudioSource.PlayOneShot(sound);
    }
}
