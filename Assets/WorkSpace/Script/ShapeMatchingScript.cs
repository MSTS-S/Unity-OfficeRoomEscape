using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMatchingScript : MonoBehaviour
{
    const string ANSWER_BLACK = "Cross";
    const string ANSWER_BLUE = "Triangle";
    const string ANSWER_RED = "Heart";

    const int TOTAL_NUMBER_OF_SHAPE = 3;
    
    public GameObject InteractionCube_L;
    public GameObject InteractionCube_C;
    public GameObject InteractionCube_R;

    public GameObject TreasureChest;

    public GameObject Key;

    private Animator animator;
    private string ANIMATER_BOOL = "OpenFlag";
    private bool AudioPlayFlag = false;

    private int ShapeMatchingClearCheck()
    {
        int CorrectShapeNumber = 0;

        if (InteractionCube_L.GetComponent<ChangeShape>().CurrentShape() == ANSWER_BLACK) CorrectShapeNumber += 1;
        if (InteractionCube_C.GetComponent<ChangeShape>().CurrentShape() == ANSWER_BLUE) CorrectShapeNumber += 1;
        if (InteractionCube_R.GetComponent<ChangeShape>().CurrentShape() == ANSWER_RED) CorrectShapeNumber += 1;

        return CorrectShapeNumber;
    }
    private void Awake()
    {
        animator = TreasureChest.GetComponent<Animator>();
        Key.SetActive(false);
    }

    void Update()
    {
        if (ShapeMatchingClearCheck() == TOTAL_NUMBER_OF_SHAPE)
        {
            animator.SetBool(ANIMATER_BOOL, true);
            Key.SetActive(true);
            if (AudioPlayFlag == false)
            {
                GetComponent<AudioSource>().Play();
                AudioPlayFlag = true;
            }
        }
    }
}
