using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{

    private RotatingPlatform m_RotatingPlatform;
    private PlatformSoundFX m_SoundFX;
    void Awake()
    {
        m_RotatingPlatform = GetComponentInParent<RotatingPlatform>();
        m_SoundFX = GetComponent<PlatformSoundFX>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagManager.PLAYER))
        {
            m_RotatingPlatform.ActivateRotation();
            m_SoundFX.PlayAudio(true);
        }
    }
}
