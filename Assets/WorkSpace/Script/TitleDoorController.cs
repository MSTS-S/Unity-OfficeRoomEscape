using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDoorController : MonoBehaviour
{
    const int LIMIT_ROTATION_MAX = 84;

    const float INPUT_FORCE = 0.0f;
    const float ROTATION_TIME = 1.0f;

    public GameObject Hinge;
    public GameObject KeyHole;

    private float Velocity = 0.2f;
    private bool ChangeStateFlag = false;
    private bool OpenFlag = false;

    private bool AudioPlayFlag = false;
    private bool MovableFlag;

    public bool DoorState()
    {
        return OpenFlag;
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

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand_L"))
        {
            if (MovableFlag == true)
            {
                if (GetHandTrigerForce_L() > INPUT_FORCE)
                {
                    if (ChangeStateFlag == false)
                    {
                        OpenFlag = true;
                        ChangeStateFlag = true;
                    }
                }
                else if (GetHandTrigerForce_L() == INPUT_FORCE)
                {
                    ChangeStateFlag = false;
                }
            }
            else if (MovableFlag == false)
            {
                if (GetHandTrigerForce_L() > INPUT_FORCE)
                {
                    if (AudioPlayFlag == false)
                    {
                        GetComponent<AudioSource>().Play();
                        AudioPlayFlag = true;
                    }
                }
                else if (GetHandTrigerForce_L() == INPUT_FORCE)
                {
                    AudioPlayFlag = false;
                }
            }
        }
        else if (other.CompareTag("Hand_R"))
        {
            if (MovableFlag == true)
            {
                if (GetHandTrigerForce_R() > INPUT_FORCE)
                {
                    if (ChangeStateFlag == false)
                    {
                        OpenFlag = true;
                        ChangeStateFlag = true;
                    }
                }
                else if (GetHandTrigerForce_R() == INPUT_FORCE)
                {
                    ChangeStateFlag = false;
                }
            }
            else if (MovableFlag == false)
            {
                if (GetHandTrigerForce_R() > INPUT_FORCE)
                {
                    if (AudioPlayFlag == false)
                    {
                        GetComponent<AudioSource>().Play();
                        AudioPlayFlag = true;
                    }
                }
                else if (GetHandTrigerForce_R() == INPUT_FORCE)
                {
                    AudioPlayFlag = false;
                }
            }
        }
    }

    void Update()
    {
        MovableFlag = KeyHole.GetComponent<KeySetScript>().OpenState();

        if (MovableFlag)
        {
            if (OpenFlag == true)
            {
                Vector3 aim = new Vector3(0.0f, 0.0f, 1.0f);
                var tarDig = Quaternion.LookRotation(aim, Vector3.up);
                var diffAngle = Vector3.Angle(Hinge.transform.forward, aim);
                var rotAngle = Mathf.SmoothDampAngle(0, diffAngle, ref Velocity, ROTATION_TIME, Mathf.Infinity);
                var nextRot = Quaternion.RotateTowards(Hinge.transform.rotation, tarDig, rotAngle);

                Hinge.transform.rotation = nextRot;

                if (Hinge.transform.localEulerAngles.y >= LIMIT_ROTATION_MAX)
                {
                    OpenFlag = false;
                    Debug.Log("OpenFinish");
                }
            }
        }
    }
}
