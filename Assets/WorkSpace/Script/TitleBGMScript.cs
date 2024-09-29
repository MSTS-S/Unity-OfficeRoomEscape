using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGMScript : MonoBehaviour
{
    public GameObject InteractiveArea;

    private void Update()
    {
        if (InteractiveArea.GetComponent<TitleDoorController>().DoorState())
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
