using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitchController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private bool isRedColor, isWhiteColor;

    void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag(TagManager.PLAYER))
        {
            if (isRedColor)
            {

                target.GetComponent<PlayerColorController>().PLAYER_COLOR = TagManager.RED;
                Debug.Log("Color Changed to Red");
            }

            if (isWhiteColor)
            {
                target.GetComponent<PlayerColorController>().PLAYER_COLOR = TagManager.WHITE;
                Debug.Log("Color Changed to White");

            }
        }
    }

}
