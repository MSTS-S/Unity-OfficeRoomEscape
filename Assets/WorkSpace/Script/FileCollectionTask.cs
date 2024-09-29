using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCollectionTask : MonoBehaviour
{
    const int TOTAL_NUMBER_OF_FILES = 6;

    public GameObject ParentGameObject;
    public GameObject FileBox;
    public GameObject File1, File2, File3, File4, File5, File6;
    public GameObject TreasureChest;
    public GameObject Shape;

    private Animator animator;
    private string ANIMATER_BOOL = "OpenFlag";

    private bool AudioPlayFlag = false;
    
    private int CountInBoxFiles()
    {
        int count = 0;
        if (File1.GetComponent<CheckPositionScript>().InBoxState() == true) count += 1;
        if (File2.GetComponent<CheckPositionScript>().InBoxState() == true) count += 1;
        if (File3.GetComponent<CheckPositionScript>().InBoxState() == true) count += 1;
        if (File4.GetComponent<CheckPositionScript>().InBoxState() == true) count += 1;
        if (File5.GetComponent<CheckPositionScript>().InBoxState() == true) count += 1;
        if (File6.GetComponent<CheckPositionScript>().InBoxState() == true) count += 1;

        return count;
    }
    private void Awake()
    {
        animator = TreasureChest.GetComponent<Animator>();
        Shape.SetActive(false);
    }

    private void Update()
    {
        if (CountInBoxFiles() == TOTAL_NUMBER_OF_FILES)
        {
            if (AudioPlayFlag == false)
            {
                animator.SetBool(ANIMATER_BOOL, true);
                GetComponent<AudioSource>().Play();
                Shape.SetActive(true);
                AudioPlayFlag = true;
            }
        }
    }
}
