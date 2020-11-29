using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float moveSmoothing = 10f;
    public float rotationSmoothing = 15f;
    private Transform player;

    private Vector3 targetForward;


    void Awake()
    {
        player = GameObject.FindWithTag(TagManager.PLAYER).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetForward = transform.forward;
        targetForward.y = 0f;
        Snap();
    }

    private void Snap()
    {
        if (player != null)
        {
            transform.position = player.position;
        }

        Vector3 forward = targetForward;
        forward.y = transform.forward.y;
        transform.forward = forward;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (player != null)
        {
            transform.position = Vector3.Lerp(transform.position, player.position,
             Time.deltaTime * moveSmoothing);
        }

        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward = Vector3.Slerp(forward, targetForward, Time.deltaTime * rotationSmoothing);
        forward.y = transform.forward.y;
        transform.forward = forward;

    }
}
