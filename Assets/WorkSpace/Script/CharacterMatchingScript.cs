using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMatchingScript : MonoBehaviour
{
    private string[] ANSWER_STRING_1 = { "null", "h", "o", "r", "s", "e" };
    private string[] ANSWER_STRING_2 = { "null", "g", "r", "e", "e", "n" };
    private string[] ANSWER_STRING_3 = { "null", "b", "o", "u", "n", "d" };

    const int TOTAL_NUMBER_OF_CHARACTER = 5;

    public GameObject InteractionCube_1;
    public GameObject InteractionCube_2;
    public GameObject InteractionCube_3;
    public GameObject InteractionCube_4;
    public GameObject InteractionCube_5;

    public GameObject TreasureChest_1;
    public GameObject TreasureChest_2;
    public GameObject TreasureChest_3;

    public GameObject Key_1;
    public GameObject Key_2;
    public GameObject Key_3;

    private string ANIMATER_BOOL = "OpenFlag";

    private bool AudioPlayFlag_1 = false;
    private bool AudioPlayFlag_2 = false;
    private bool AudioPlayFlag_3 = false;

    private int CheckString_1()
    {
        int CorrectNumber = 0;

        if (InteractionCube_1.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_1[1]) CorrectNumber += 1;
        if (InteractionCube_2.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_1[2]) CorrectNumber += 1;
        if (InteractionCube_3.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_1[3]) CorrectNumber += 1;
        if (InteractionCube_4.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_1[4]) CorrectNumber += 1;
        if (InteractionCube_5.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_1[5]) CorrectNumber += 1;

        return CorrectNumber;
    }

    private int CheckString_2()
    {
        int CorrectNumber = 0;

        if (InteractionCube_1.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_2[1]) CorrectNumber += 1;
        if (InteractionCube_2.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_2[2]) CorrectNumber += 1;
        if (InteractionCube_3.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_2[3]) CorrectNumber += 1;
        if (InteractionCube_4.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_2[4]) CorrectNumber += 1;
        if (InteractionCube_5.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_2[5]) CorrectNumber += 1;

        return CorrectNumber;
    }

    private int CheckString_3()
    {
        int CorrectNumber = 0;

        if (InteractionCube_1.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_3[1]) CorrectNumber += 1;
        if (InteractionCube_2.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_3[2]) CorrectNumber += 1;
        if (InteractionCube_3.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_3[3]) CorrectNumber += 1;
        if (InteractionCube_4.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_3[4]) CorrectNumber += 1;
        if (InteractionCube_5.GetComponent<ChangeCharacter>().CurrentCharacter() == ANSWER_STRING_3[5]) CorrectNumber += 1;

        return CorrectNumber;
    }

    private void CharacterMatchingClearCheck()
    {
        if (CheckString_1() == TOTAL_NUMBER_OF_CHARACTER)
        {
            TreasureChest_1.GetComponent<Animator>().SetBool(ANIMATER_BOOL, true);
            Key_1.SetActive(true);
            if (AudioPlayFlag_1 == false)
            {
                GetComponent<AudioSource>().Play();
                AudioPlayFlag_1 = true;
            }
        }

        if (CheckString_2() == TOTAL_NUMBER_OF_CHARACTER)
        {
            TreasureChest_2.GetComponent<Animator>().SetBool(ANIMATER_BOOL, true);
            Key_2.SetActive(true);
            if (AudioPlayFlag_2 == false)
            {
                GetComponent<AudioSource>().Play();
                AudioPlayFlag_2 = true;
            }
        }

        if (CheckString_3() == TOTAL_NUMBER_OF_CHARACTER)
        {
            TreasureChest_3.GetComponent<Animator>().SetBool(ANIMATER_BOOL, true);
            Key_3.SetActive(true);
            if (AudioPlayFlag_3 == false)
            {
                GetComponent<AudioSource>().Play();
                AudioPlayFlag_3 = true;
            }
        }
    }

    private void Awake()
    {
        Key_1.SetActive(false);
        Key_2.SetActive(false);
        Key_3.SetActive(false);
    }

    void Update()
    {
        CharacterMatchingClearCheck();
    }
}
