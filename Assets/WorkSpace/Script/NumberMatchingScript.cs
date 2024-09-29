using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberMatchingScript : MonoBehaviour
{
    const int ANSWER_DIGIT_1 = 8;
    const int ANSWER_DIGIT_2 = 2;
    const int ANSWER_DIGIT_3 = 6;
    const int ANSWER_DIGIT_4 = 7;
    const int ANSWER_DIGIT_5 = 2;
    const int ANSWER_DIGIT_6 = 3;

    const int TOTAL_NUMBER_OF_DIGIT = 6;

    public GameObject InteractionCube_1;
    public GameObject InteractionCube_2;
    public GameObject InteractionCube_3;
    public GameObject InteractionCube_4;
    public GameObject InteractionCube_5;
    public GameObject InteractionCube_6;

    public GameObject TreasureChest;

    public GameObject ReceptionRoomKey;

    private Animator animator;
    private string ANIMATER_BOOL = "OpenFlag";
    private bool AudioPlayFlag = false;

    private int NumberMatchingClearCheck()
    {
        int CorrectNumber = 0;

        if (InteractionCube_1.GetComponent<ChangeNumber>().CurrentNumber() == ANSWER_DIGIT_1) CorrectNumber += 1;
        if (InteractionCube_2.GetComponent<ChangeNumber>().CurrentNumber() == ANSWER_DIGIT_2) CorrectNumber += 1;
        if (InteractionCube_3.GetComponent<ChangeNumber>().CurrentNumber() == ANSWER_DIGIT_3) CorrectNumber += 1;
        if (InteractionCube_4.GetComponent<ChangeNumber>().CurrentNumber() == ANSWER_DIGIT_4) CorrectNumber += 1;
        if (InteractionCube_5.GetComponent<ChangeNumber>().CurrentNumber() == ANSWER_DIGIT_5) CorrectNumber += 1;
        if (InteractionCube_6.GetComponent<ChangeNumber>().CurrentNumber() == ANSWER_DIGIT_6) CorrectNumber += 1;

        return CorrectNumber;
    }
    private void Awake()
    {
        animator = TreasureChest.GetComponent<Animator>();
        ReceptionRoomKey.SetActive(false);
    }

    void Update()
    {
        if (NumberMatchingClearCheck() == TOTAL_NUMBER_OF_DIGIT)
        {
            animator.SetBool(ANIMATER_BOOL, true);
            if (AudioPlayFlag == false)
            {
                GetComponent<AudioSource>().Play();
                AudioPlayFlag = true;
                ReceptionRoomKey.SetActive(true);
            }
        }
    }
}
