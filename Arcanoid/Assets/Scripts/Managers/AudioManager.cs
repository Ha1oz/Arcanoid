using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingleTone<AudioManager>
{

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip exposion, shoot;

    private void Awake()
    {
        if (Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(int idClip = 0) {
        if (idClip == 0)
        {
            source.PlayOneShot(shoot);
        }
        else {
            source.PlayOneShot(exposion);
        }
    }

}
