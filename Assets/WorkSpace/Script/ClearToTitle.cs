using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearToTitle : MonoBehaviour
{
    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch) && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
