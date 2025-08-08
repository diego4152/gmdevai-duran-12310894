using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioSource sfxSource, AudioClip sourceClip)
    {
        sfxSource.clip = sourceClip;
        sfxSource.PlayOneShot(sourceClip, sfxSource.volume);
    }
}