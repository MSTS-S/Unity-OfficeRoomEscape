using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCloseScript : MonoBehaviour
{
    const int LIMIT_ROTATION_MIN = 0;
    const int AUDIO_PLAY_ANGLE = 10;
    const float BLACK_TIME = 3.0f;
    const float BLACK_OUT_TIME = 1.0f;
    const float ROTATION_TIME = 1.0f;

    public GameObject OVRPlayerController;
    public GameObject Wall;
    public GameObject Hinge;
    public GameObject InteractiveArea;

    private float Velocity = 0.2f;
    private float TimeBlack = 0.0f;
    private float TimeTransition = 0.0f;

    private bool CloseFlag = false;
    private bool AudioPlayFlag = false;

    private void Awake()
    {
        Wall.SetActive(false);
    }

    private void Update()
    {
        if (OVRPlayerController.GetComponent<SceneTransition_1>().CenterState())
        {
            InteractiveArea.SetActive(false);

            Vector3 aim = new Vector3(-1.0f, 0.0f, 0.0f);
            var tarDig = Quaternion.LookRotation(aim, Vector3.up);
            var diffAngle = Vector3.Angle(Hinge.transform.forward, aim);
            var rotAngle = Mathf.SmoothDampAngle(0, diffAngle, ref Velocity, ROTATION_TIME, Mathf.Infinity);
            var nextRot = Quaternion.RotateTowards(Hinge.transform.rotation, tarDig, rotAngle);

            Hinge.transform.rotation = nextRot;

            if (Hinge.transform.localEulerAngles.y <= AUDIO_PLAY_ANGLE)
            {
                if (AudioPlayFlag == false)
                {
                    GetComponent<AudioSource>().Play();
                    AudioPlayFlag = true;
                }
            }

            if (Hinge.transform.localEulerAngles.y <= LIMIT_ROTATION_MIN)
            {
                TimeBlack += Time.deltaTime;

                if (TimeBlack > BLACK_OUT_TIME)
                {
                    Wall.SetActive(true);
                    CloseFlag = true;
                }
            }
        }

        if (CloseFlag)
        {
            TimeTransition += Time.deltaTime;

            if (TimeTransition > BLACK_TIME)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
