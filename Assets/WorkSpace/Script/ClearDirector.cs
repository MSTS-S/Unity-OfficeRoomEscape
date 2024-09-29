using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDirector : MonoBehaviour
{
    public GameObject InteractiveArea;
    public GameObject GameClearObject;

    private bool ClearFlag = false;

    private void Awake()
    {
        GameClearObject.SetActive(false);
    }

    private void Update()
    {
        if (InteractiveArea.GetComponent<DoorController_Final>().ClearState())
        {
            if (ClearFlag == false)
            {
                GameClearObject.SetActive(true);
                ClearFlag = true;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
