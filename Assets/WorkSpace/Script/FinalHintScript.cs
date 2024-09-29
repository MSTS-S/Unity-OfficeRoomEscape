using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalHintScript : MonoBehaviour
{
    public GameObject KeyHole_F;
    public GameObject KeyHole_R;
    public GameObject FinalHint;

    private void Awake()
    {
        FinalHint.SetActive(false);
    }

    void Update()
    {
        if (KeyHole_F.GetComponent<KeySetScript>().KeySetState() && KeyHole_R.GetComponent<KeySetScript>().KeySetState())
        {
            FinalHint.SetActive(true);
        }
    }
}
