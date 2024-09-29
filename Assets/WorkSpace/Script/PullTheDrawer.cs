using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullTheDrawer : MonoBehaviour
{
    const float LIMIT_POSITION_MAX = 0.4f;
    const float LIMIT_POSITION_MIN = -0.06f;

    public GameObject HandAnchor_L;
    public GameObject HandAnchor_R;

    public bool RotateY000, RotateY090, RotateY180, RotateY270;

    private Vector3 DrawerPotition;
    private Vector3 PreHandPosition_L;
    private Vector3 CurHandPosition_L;
    private Vector3 PreHandPosition_R;
    private Vector3 CurHandPosition_R;

    private float diff;

    private bool MovableFlag_L = false;
    private bool MovableFlag_R = false;

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

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand_L"))
        {
            if (GetHandTrigerForce_L() > 0.0f)
            {
                MovableFlag_L = true;
            }
            else
            {
                MovableFlag_L = false;
            }
        }
        else if (other.CompareTag("Hand_R"))
        {
            if (GetHandTrigerForce_R() > 0.0f)
            {
                MovableFlag_R = true;
            }
            else
            {
                MovableFlag_R = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand_L"))
        {
            MovableFlag_L = false;
        }
        if (other.CompareTag("Hand_R"))
        {
            MovableFlag_R = false;
        }
    }

    private void GetCurrentPosition()
    {
        DrawerPotition = transform.localPosition;
        CurHandPosition_L = HandAnchor_L.transform.position;
        CurHandPosition_R = HandAnchor_R.transform.position;
    }

    private void Awake()
    {
        DrawerPotition = transform.localPosition;
        PreHandPosition_L = HandAnchor_L.transform.position;
        PreHandPosition_R = HandAnchor_R.transform.position;
    }

    private void Update()
    {
        GetCurrentPosition();

        if (MovableFlag_L == true)
        {
            if (RotateY000) diff = CurHandPosition_L.z - PreHandPosition_L.z;
            else if (RotateY090) diff = CurHandPosition_L.x - PreHandPosition_L.x;
            else if (RotateY180) diff = PreHandPosition_L.z - CurHandPosition_L.z;
            else if (RotateY270) diff = PreHandPosition_L.x - CurHandPosition_L.x;
            transform.localPosition = DrawerPotition + new Vector3(0, 0, diff);
        }

        if (MovableFlag_R == true)
        {
            if (RotateY000) diff = CurHandPosition_R.z - PreHandPosition_R.z;
            else if (RotateY090) diff = CurHandPosition_R.x - PreHandPosition_R.x;
            else if (RotateY180) diff = PreHandPosition_R.z - CurHandPosition_R.z;
            else if (RotateY270) diff = PreHandPosition_R.x - CurHandPosition_R.x;

            transform.localPosition = DrawerPotition + new Vector3(0, 0, diff);
        }

        PreHandPosition_L = CurHandPosition_L;
        PreHandPosition_R = CurHandPosition_R;

        if (transform.localPosition.z > LIMIT_POSITION_MAX)
        {
            this.transform.localPosition = new Vector3(0, 0, LIMIT_POSITION_MAX);
        }
        if (transform.localPosition.z < LIMIT_POSITION_MIN)
        {
            this.transform.localPosition = new Vector3(0, 0, LIMIT_POSITION_MIN);
        }
    }
}
