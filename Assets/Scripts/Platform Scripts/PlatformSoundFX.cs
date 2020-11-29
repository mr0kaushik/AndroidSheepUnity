using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSoundFX : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource m_AudioFX;

    void Awake()
    {
        m_AudioFX = GetComponent<AudioSource>();
    }

    public void PlayAudio(bool play)
    {
        if (play)
            m_AudioFX.Play();
        else
            m_AudioFX.Stop();
    }
}
