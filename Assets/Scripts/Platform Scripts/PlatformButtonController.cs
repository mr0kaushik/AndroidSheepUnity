using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButtonController : MonoBehaviour
{

    public MovingPlatform[] movingPlatforms;


    [SerializeField]
    private bool movedPlatformsPoint;
    [SerializeField]
    private bool isWhiteButton, isRedButton;

    void OnTriggerEnter(Collider target)
    {

        if (target.CompareTag(TagManager.PLAYER))
        {
            if (isWhiteButton)
            {
                if (!target.GetComponent<PlayerColorController>().PLAYER_COLOR.Equals(TagManager.WHITE))
                {

                    return;
                }
            }


            if (isRedButton)
            {
                if (!target.GetComponent<PlayerColorController>().PLAYER_COLOR.Equals(TagManager.RED))
                {

                    return;
                }
            }

            if (!movedPlatformsPoint)
            {

                movedPlatformsPoint = true;
                for (int i = 0; i < movingPlatforms.Length; i++)
                {
                    movingPlatforms[i].ActivateMovementToFinal();
                }
            }
            else
            {
                movedPlatformsPoint = false;
                for (int i = 0; i < movingPlatforms.Length; i++)
                {
                    movingPlatforms[i].ActivateMovementToInitial();

                }
            }


        }

    }
}
