using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition_1 : MonoBehaviour
{
    const int RADIUS = 1;

    public GameObject LightCircle;
    public GameObject Arrow;

    private bool CenterFlag = false;

    public bool CenterState()
    {
        return CenterFlag;
    }

    private void Update()
    {
        if (Vector3.Distance(LightCircle.transform.position , transform.position) < RADIUS)
        {
            CenterFlag = true;
            LightCircle.SetActive(false);
            Arrow.SetActive(false);
        }
    }
}
