using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCharacterMatchingScript : MonoBehaviour
{
    private string[] ANSWER_STRING_1 = { "null", "c", "l", "e", "a", "r" };

    const int TOTAL_NUMBER_OF_CHARACTER = 5;

    public GameObject InteractionCube_1;
    public GameObject InteractionCube_2;
    public GameObject InteractionCube_3;
    public GameObject InteractionCube_4;
    public GameObject InteractionCube_5;

    public GameObject TreasureChest;

    public GameObject FinalKey;

    private string ANIMATER_BOOL = "OpenFlag";

    private bool AudioPlayFlag = false;

    private int CheckString()
    {
        int CorrectNumber = 0;

        if (InteractionCube_1.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_1[1]) CorrectNumber += 1;
        if (InteractionCube_2.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_1[2]) CorrectNumber += 1;
        if (InteractionCube_3.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_1[3]) CorrectNumber += 1;
        if (InteractionCube_4.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_1[4]) CorrectNumber += 1;
        if (InteractionCube_5.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_1[5]) CorrectNumber += 1;

        return CorrectNumber;
    }


    private void CharacterMatchingClearCheck()
    {
        if (CheckString() == TOTAL_NUMBER_OF_CHARACTER)
        {
            TreasureChest.GetComponent<Animator>().SetBool(ANIMATER_BOOL, true);
            FinalKey.SetActive(true);
            if (AudioPlayFlag == false)
            {
                GetComponent<AudioSource>().Play();
                AudioPlayFlag = true;
            }
        }
    }

    private void Awake()
    {
        FinalKey.SetActive(false);
    }

    void Update()
    {
        CharacterMatchingClearCheck();
    }
}
