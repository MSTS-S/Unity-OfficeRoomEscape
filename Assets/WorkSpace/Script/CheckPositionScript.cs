using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPositionScript : MonoBehaviour
{
    public string Tag;

    private GameObject ParentGameObject;
    private bool InBoxFlag = false;
    private bool AudioFlag = false;

    public bool InBoxState()
    {
        return InBoxFlag;
    }

    private float GetHandTrigerForce_L()
    {
        float HandTriggerForce_L = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        return HandTriggerForce_L;
    }

    private float GetHandTrigerForce_R()
    {
        float HandTriggerForce_R = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        return HandTriggerForce_R;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Tag) && this.transform.parent.CompareTag("Untagged"))
        {
            if (AudioFlag == false)
            {
                InBoxFlag = true;
                AudioFlag = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tag))
        {
            InBoxFlag = false;
            AudioFlag = false;
        }
    }

    private void Awake()
    {
        ParentGameObject = GameObject.Find("ParentGameObject");
    }
}
