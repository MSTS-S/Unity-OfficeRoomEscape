using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCrickScript : MonoBehaviour
{
    const float INPUT_FORCE = 0.0f;

    public GameObject ComputerScreen;

    private bool ScreenOnFlag = false;
    private bool ChangeFlag_L = false;
    private bool ChangeFlag_R = false;

    private void ChangeScreenState()
    {
        if (ScreenOnFlag == true)
        {
            ScreenOnFlag = false;
        }
        else if (ScreenOnFlag == false)
        {
            ScreenOnFlag = true;
        }
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
            if (GetHandTrigerForce_L() > INPUT_FORCE)
            {
                if (ChangeFlag_L == false)
                {
                    ChangeFlag_L = true;
                    ChangeScreenState();
                    GetComponent<AudioSource>().Play();
                }
            }
            else if (GetHandTrigerForce_L() == INPUT_FORCE)
            {
                ChangeFlag_L = false;
            }
        }
        else if (other.CompareTag("Hand_R"))
        {
            if (GetHandTrigerForce_R() > INPUT_FORCE)
            {
                if (ChangeFlag_R == false)
                {
                    ChangeFlag_R = true;
                    ChangeScreenState();
                    GetComponent<AudioSource>().Play();
                }
            }
            else if (GetHandTrigerForce_R() == INPUT_FORCE)
            {
                ChangeFlag_R = false;
            }
        }
    }

    private void Awake()
    {
        ComputerScreen.SetActive(false);
    }

    private void Update()
    {
        if (ScreenOnFlag == true)
        {
            ComputerScreen.SetActive(true);
        }
        else if ((ScreenOnFlag == false))
        {
            ComputerScreen.SetActive(false);
        }
    }
}
