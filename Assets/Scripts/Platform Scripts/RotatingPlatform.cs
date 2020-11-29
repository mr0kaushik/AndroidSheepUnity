using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{


    [SerializeField]
    private float m_SmoothRotate = 1f;


    [SerializeField]
    private float m_DeactivateTimer = 5f;


    [SerializeField]
    private Vector3 m_RotationAngles;
    [SerializeField]
    private bool m_CanRotate;

    private PlatformSoundFX m_SoundFX;


    private bool m_BackToInitialRotation;

    private Quaternion m_InitialRotation;



    void Awake()
    {
        m_InitialRotation = transform.rotation;
        m_SoundFX = GetComponent<PlatformSoundFX>();
    }


    void Update()
    {

        RotatePlatform();
    }

    private void RotatePlatform()
    {
        if (m_CanRotate)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.Euler(m_RotationAngles.x, m_RotationAngles.y, m_RotationAngles.z),
            m_SmoothRotate * Time.deltaTime);
        }
    }


    public void ActivateRotation()
    {
        if (!m_CanRotate)
        {
            m_CanRotate = true;
            m_SoundFX.PlayAudio(true);
            Invoke("DeactivateRotation", m_DeactivateTimer);
        }
    }

    private void DeactivateRotation()
    {
        m_CanRotate = false;
        m_SoundFX.PlayAudio(false);
    }
}

