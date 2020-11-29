using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField]
    private float m_HalfedDistance = 15f; // Trigger Point is halfed of the total platform distance
    [SerializeField]
    private float m_SmoothMovement = 0.3f; // Smoothing value for Platform Movement
    [SerializeField]
    private float m_Timer = 1f; // Time for smooth


    [SerializeField]
    private Transform m_MovePoint; // Final Position of Platform
    private Vector3 m_StartPosition; // Initial Position of Platform

    private float m_InitialMovement; // Initial Smoothing value
    private bool m_SmoothMovementHalfed; // Flag to be used to determine if have already halfed the speed for not
    private bool m_CanMove; // Platform Can move
    private bool m_MoveToInitial; // Flag to move the platform to its inital position

    [SerializeField]
    private bool m_ActivateMovementInStart; //


    private DoorController m_DoorController;

    [SerializeField]
    private bool m_DeactivateDoors;

    private PlatformSoundFX m_PlatformSoundFX;


    private RotatingPlatform m_RotatingPlatform;

    [SerializeField]
    private bool m_ActivateRotation;

    void Awake()
    {
        m_StartPosition = transform.position;
        m_InitialMovement = m_SmoothMovement;

        // activate doors
        m_DoorController = GetComponent<DoorController>();

        // active sounds
        m_PlatformSoundFX = GetComponent<PlatformSoundFX>();
        m_RotatingPlatform = GetComponent<RotatingPlatform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (m_ActivateMovementInStart)
        {
            // Debug.Log(A
            Invoke("ActivateMovementToFinal", m_Timer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveToFinalPosition();
        MoveToIntialPosition();
    }

    private void MoveToFinalPosition()
    {
        if (m_CanMove)
        {
            MovePlatform(m_MovePoint.position, true);
            // transform.position = Vector3.MoveTowards(transform.position, m_MovePoint.position, m_SmoothMovement);

            // if (Vector3.Distance(transform.position, m_MovePoint.position) <= m_HalfedDistance)
            // {
            //     if (!m_SmoothMovementHalfed)
            //     {
            //         m_SmoothMovement /= 2f;
            //         m_SmoothMovementHalfed = true;
            //     }
            // }

            // if (Vector3.Distance(transform.position, m_MovePoint.position) == 0f)
            // {

            //     Debug.Log("Stop Platform Movement");
            //     m_CanMove = false;

            //     if (m_SmoothMovementHalfed)
            //     {
            //         m_SmoothMovement = m_InitialMovement;
            //         m_SmoothMovementHalfed = false;
            //     }

            //     //deactivate doors
            //     if (m_DeactivateDoors)
            //     {
            //         m_DoorController.OpenDoors();
            //     }
            //     //pause sounds
            //     m_PlatformSoundFX.PlayAudio(false);
            // }

        }
    }


    // Provide the functionality of movement to the platform
    public void ActivateMovementToFinal()
    {
        m_CanMove = true;

        // play sound
        m_PlatformSoundFX.PlayAudio(true);
        // rotate

        if (m_ActivateRotation)
        {
            m_RotatingPlatform.ActivateRotation();
        }
    }

    public void ActivateMovementToInitial()
    {
        m_MoveToInitial = true;
        m_PlatformSoundFX.PlayAudio(true);
    }

    void MoveToIntialPosition()
    {
        if (m_MoveToInitial)
        {
            MovePlatform(m_StartPosition, false);
            // transform.position = Vector3.MoveTowards(transform.position, m_StartPosition, m_SmoothMovement);
            // if (Vector3.Distance(transform.position, m_StartPosition) <= m_HalfedDistance)
            // {
            //     if (!m_SmoothMovementHalfed)
            //     {
            //         m_SmoothMovement /= 2f;
            //         m_SmoothMovementHalfed = true;
            //     }
            // }

            // if (Vector3.Distance(transform.position, m_StartPosition) == 0f)
            // {

            //     m_MoveToInitial = false;

            //     if (m_SmoothMovementHalfed)
            //     {
            //         m_SmoothMovement = m_InitialMovement;
            //         m_SmoothMovementHalfed = false;
            //     }
            //     //pause sounds
            //     m_PlatformSoundFX.PlayAudio(false);
            // }

        }
    }

    void MovePlatform(Vector3 position, bool towardsFinal)
    {

        transform.position = Vector3.MoveTowards(transform.position, position, m_SmoothMovement);

        if (Vector3.Distance(transform.position, position) <= m_HalfedDistance)
        {
            if (!m_SmoothMovementHalfed)
            {
                m_SmoothMovement /= 2f;
                m_SmoothMovementHalfed = true;
            }
        }

        if (Vector3.Distance(transform.position, position) == 0f)
        {
            if (m_SmoothMovementHalfed)
            {
                m_SmoothMovement = m_InitialMovement;
                m_SmoothMovementHalfed = false;
            }

            if (towardsFinal)
            {
                m_CanMove = false;
                //deactivate doors
                if (m_DeactivateDoors)
                {
                    m_DoorController.OpenDoors();
                }
            }
            else
            {
                m_MoveToInitial = false;
            }

            //pause sounds
            m_PlatformSoundFX.PlayAudio(false);
        }

    }
}
