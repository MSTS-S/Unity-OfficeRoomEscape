using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySetScript : MonoBehaviour
{
    const float SET_KEY_RADIUS = 0.75f;

    public GameObject Key;
    public GameObject KeyHole;
    public GameObject KeySpace;

    public Vector3 KeySetPosition;
    public Vector3 KeySetRotation;

    private Vector3 KeyBodyPosition;
    private Vector3 KeyHolePosition;

    private bool KeySettableFlag = false;
    private bool AudioPlayFlag = false;

    private bool OpenFlag = false;
    private bool KeySetFlag = false;

    public bool KeySetState()
    {
        return KeySetFlag;
    }

    public bool OpenState()
    {
        return OpenFlag;
    }

    private void Start()
    {
        KeySpace.SetActive(false);
        Debug.Log("KeyPosition : " + KeyHole.transform.position);
    }

    void Update()
    {
        KeyBodyPosition = Key.transform.position;
        KeyHolePosition = KeyHole.transform.position;

        if (OpenFlag == false)
        {
            if (Vector3.Distance(KeyBodyPosition, KeyHolePosition) < SET_KEY_RADIUS)
            {
                KeySpace.SetActive(true);
                KeySettableFlag = true;
            }
            else
            {
                KeySpace.SetActive(false);
                KeySettableFlag = false;
            }

            if (KeySettableFlag)
            {
                if (Key.transform.parent.CompareTag("Untagged"))
                {
                    KeySetFlag = true;
                    Key.GetComponent<Rigidbody>().isKinematic = true;
                    Key.transform.position = KeySpace.transform.position;
                    Key.transform.eulerAngles = KeySpace.transform.eulerAngles;
                    KeySpace.SetActive(false);
                    OpenFlag = true;
                    Key.transform.parent = this.transform;
                    if (AudioPlayFlag == false)
                    {
                        GetComponent<AudioSource>().Play();
                        AudioPlayFlag = true;
                    }
                    KeySettableFlag = false;
                }
            }
        }

        if(OpenFlag == true)
        {
            if (Vector3.Distance(KeyBodyPosition, KeyHolePosition) < SET_KEY_RADIUS)
            {
                if (Key.transform.parent.CompareTag("Hand_L") || Key.transform.parent.CompareTag("Hand_R"))
                {
                    KeySpace.SetActive(true);
                    KeySettableFlag = true;
                    AudioPlayFlag = false;
                }
            }
            else
            {
                KeySpace.SetActive(false);
                KeySettableFlag = false;
            }

            if (KeySettableFlag)
            {
                if (Key.transform.parent.CompareTag("Untagged"))
                {
                    KeySetFlag = true;
                    Key.GetComponent<Rigidbody>().isKinematic = true;
                    Key.transform.position = KeySpace.transform.position;
                    Key.transform.eulerAngles = KeySpace.transform.eulerAngles;
                    KeySpace.SetActive(false);
                    OpenFlag = true;
                    Key.transform.parent = this.transform;
                    if (AudioPlayFlag == false)
                    {
                        GetComponent<AudioSource>().Play();
                        AudioPlayFlag = true;
                    }
                    KeySettableFlag = false;
                }
            }
        }

    }
}
