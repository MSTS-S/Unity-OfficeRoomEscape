using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeNumber : MonoBehaviour
{
    const float INPUT_FORCE = 0.0f;
    const int PLUS = 1;
    const int MINUS = -1;

    public GameObject NumberOutputField;

    private bool ChangeFlag_L = false;
    private bool ChangeFlag_R = false;

    private int Number;

    public int CurrentNumber()
    {
        return Number;
    }

    private void SetDisplayNumber(int n)
    {
        NumberOutputField.GetComponent<TextMeshProUGUI>().text = n.ToString();
    }

    private void AlterNumber(int n)
    {
        Number += n;

        if (Number == 10) Number = 0;
        if (Number == -1) Number = 9;
        SetDisplayNumber(Number);
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
                    AlterNumber(MINUS);
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
                    AlterNumber(PLUS);
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
        Number = 0;
        SetDisplayNumber(0);
    }
}