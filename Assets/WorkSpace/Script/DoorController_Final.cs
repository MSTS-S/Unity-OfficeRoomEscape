using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController_Final : MonoBehaviour
{
    const int LIMIT_ROTATION_MAX = 84;
    const int LIMIT_ROTATION_MIN = 0;

    const float INPUT_FORCE = 0.0f;
    const float ROTATION_TIME = 1.0f;

    public GameObject Hinge;
    public GameObject KeyHole;

    private float Velocity = 0.2f;
    private bool ChangeStateFlag = false;
    private bool OpenFlag = false;
    private bool CloseFlag = false;

    private bool AudioPlayFlag = false;
    private bool MovableFlag;

    private bool ClearFlag = false;

    public bool ClearState()
    {
        return ClearFlag;
    }

    private enum DOOR_STATE
    {
        Open,
        Close
    }

    DOOR_STATE DoorState;


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
                    if (ChangeStateFlag == false && DoorState == DOOR_STATE.Close)
                    {
                        DoorState = DOOR_STATE.Open;
                        OpenFlag = true;
                        CloseFlag = false;
                        ChangeStateFlag = true;
                    }
                    else if (ChangeStateFlag == false && DoorState == DOOR_STATE.Open)
                    {
                        DoorState = DOOR_STATE.Close;
                        OpenFlag = false;
                        CloseFlag = true;
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
                    if (ChangeStateFlag == false && DoorState == DOOR_STATE.Close)
                    {
                        DoorState = DOOR_STATE.Open;
                        OpenFlag = true;
                        CloseFlag = false;
                        ChangeStateFlag = true;
                    }
                    else if (ChangeStateFlag == false && DoorState == DOOR_STATE.Open)
                    {
                        DoorState = DOOR_STATE.Close;
                        OpenFlag = false;
                        CloseFlag = true;
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
    private void Awake()
    {
        DoorState = DOOR_STATE.Close;
    }

    void Update()
    {
        MovableFlag = KeyHole.GetComponent<KeySetScript>().OpenState();

        if (MovableFlag)
        {
            if (OpenFlag == true)
            {
                ClearFlag = true;
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

            else if (CloseFlag == true)
            {
                Vector3 aim = new Vector3(-1.0f, 0.0f, 0.0f);
                var tarDig = Quaternion.LookRotation(aim, Vector3.up);
                var diffAngle = Vector3.Angle(Hinge.transform.forward, aim);
                var rotAngle = Mathf.SmoothDampAngle(0, diffAngle, ref Velocity, ROTATION_TIME, Mathf.Infinity);
                var nextRot = Quaternion.RotateTowards(Hinge.transform.rotation, tarDig, rotAngle);

                Hinge.transform.rotation = nextRot;

                if (Hinge.transform.localEulerAngles.y <= LIMIT_ROTATION_MIN)
                {
                    CloseFlag = false;
                    Debug.Log("CloseFinish");
                }
            }
        }
    }
}
