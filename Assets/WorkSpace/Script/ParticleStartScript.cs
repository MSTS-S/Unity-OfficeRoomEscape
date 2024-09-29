using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStartScript : MonoBehaviour
{
    public GameObject InteractiveArea;

    private bool ClearFlag = false;

    private void Update()
    {
        if (InteractiveArea.GetComponent<DoorController_Final>().ClearState())
        {
            if (ClearFlag == false)
            {
                GetComponent<ParticleSystem>().Play();
                ClearFlag = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<ParticleSystem>().Play();
        }
    }
}
