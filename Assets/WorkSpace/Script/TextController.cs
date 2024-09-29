using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour
{
    const float SPEED = 3.0f;
    private float time = 0.0f;

    private Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * SPEED;
        color.a = Mathf.Sin(time);

        return color;
    }

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().color = GetAlphaColor(GetComponent<TextMeshProUGUI>().color);
    }
}
