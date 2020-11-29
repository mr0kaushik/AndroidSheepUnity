using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private Transform[] children;

    [SerializeField]
    private bool m_DeactivateInStart;
    // Start is called before the first frame update
    void Start()
    {
        children = transform.GetComponentsInChildren<Transform>();
        if(m_DeactivateInStart){
            OpenDoors();
        }
    }

    public void OpenDoors()
    {
        foreach (Transform t in children)
        {
            if (t.CompareTag(TagManager.DOOR))
            {
                t.gameObject.GetComponent<Collider>().isTrigger = true;
            }
        }
    }

}
