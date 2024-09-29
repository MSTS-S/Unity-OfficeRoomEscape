using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    const float SPEED = 1.2f;

    void Update()
    {
        transform.Rotate(0, SPEED, 0);
    }
}
