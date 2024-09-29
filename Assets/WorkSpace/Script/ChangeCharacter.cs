using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeCharacter : MonoBehaviour
{
    const float INPUT_FORCE = 0.0f;
    const int TOTAL_NUMBER_OF_CHARACTER = 26;
    const int PLUS = 1;
    const int MINUS = -1;

    public GameObject CharacterOutputField;


    private bool ChangeFlag_L = false;
    private bool ChangeFlag_R = false;

    private int Number;

    private string[] Alphabet = {"null", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                                         "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

    public string CurrentCharacter()
    {
        return Alphabet[Number];
    }

    private void SetDisplayCharacter(int n)
    {
        CharacterOutputField.GetComponent<TextMeshProUGUI>().text = Alphabet[n];
    }

    private void AlterCharacter(int n)
    {
        Number += n;

        if (Number == TOTAL_NUMBER_OF_CHARACTER + 1) Number = 1;
        if (Number == 0) Number = TOTAL_NUMBER_OF_CHARACTER;
        SetDisplayCharacter(Number);
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
                    AlterCharacter(MINUS);
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
                    AlterCharacter(PLUS);
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
        Number = 1;
        SetDisplayCharacter(1);
    }
}
