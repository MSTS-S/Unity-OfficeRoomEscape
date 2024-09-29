using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShape : MonoBehaviour
{
    const float INPUT_FORCE = 0.0f;

    public GameObject Circle, Cross, Heart, Square, Star, Triangle;

    private bool ChangeFlag_L = false;
    private bool ChangeFlag_R = false;

    public enum SHAPE_TYPE
    {
        Circle,
        Cross,
        Heart,
        Square,
        Star,
        Triangle,
    }

    SHAPE_TYPE Shape;

    public string CurrentShape()
    {
        string shape = "Null";

        if (Shape == SHAPE_TYPE.Circle)
        {
            shape = "Circle";
        }
        else if (Shape == SHAPE_TYPE.Cross)
        {
            shape = "Cross";
        }
        else if (Shape == SHAPE_TYPE.Heart)
        {
            shape = "Heart";
        }
        else if (Shape == SHAPE_TYPE.Square)
        {
            shape = "Square";
        }
        else if (Shape == SHAPE_TYPE.Star)
        {
            shape = "Star";
        }
        else if (Shape == SHAPE_TYPE.Triangle)
        {
            shape = "Triangle";
        }

        return shape;
    }

    private void AlterShape()
    {
        if (Shape == SHAPE_TYPE.Circle)
        {
            Shape = SHAPE_TYPE.Cross;
            Circle.SetActive(false);
            Cross.SetActive(true);
        }
        else if (Shape == SHAPE_TYPE.Cross)
        {
            Shape = SHAPE_TYPE.Heart;
            Cross.SetActive(false);
            Heart.SetActive(true);
        }
        else if (Shape == SHAPE_TYPE.Heart)
        {
            Shape = SHAPE_TYPE.Square;
            Heart.SetActive(false);
            Square.SetActive(true);
        }
        else if (Shape == SHAPE_TYPE.Square)
        {
            Shape = SHAPE_TYPE.Star;
            Square.SetActive(false);
            Star.SetActive(true);
        }
        else if (Shape == SHAPE_TYPE.Star)
        {
            Shape = SHAPE_TYPE.Triangle;
            Star.SetActive(false);
            Triangle.SetActive(true);
        }
        else if (Shape == SHAPE_TYPE.Triangle)
        {
            Shape = SHAPE_TYPE.Circle;
            Triangle.SetActive(false);
            Circle.SetActive(true);
        }

    }

    private float GetHandTrigerForce_L()
    {
        float HandTriggerForce_L = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        return HandTriggerForce_L;
    }

    private float GetHandTrigerForce_R()
    {
        float HandTriggerForce_R = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        return HandTriggerForce_R;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand_L"))
        {
            if (GetHandTrigerForce_L() > INPUT_FORCE)
            {
                if (ChangeFlag_L == false)
                {
                    ChangeFlag_L = true;
                    AlterShape();
                }
            }
            else if (GetHandTrigerForce_L() == INPUT_FORCE)
            {
                ChangeFlag_L = false;
            }
        }
        else if (other.CompareTag("Hand_R"))
        {
            if (GetHandTrigerForce_R() > INPUT_FORCE)
            {
                if (ChangeFlag_R == false)
                {
                    ChangeFlag_R = true;
                    AlterShape();
                }
            }
            else if (GetHandTrigerForce_R() == INPUT_FORCE)
            {
                ChangeFlag_R = false;
            }
        }
    }

    private void Awake()
    {
        Shape = SHAPE_TYPE.Circle;
        Circle.SetActive(true);
        Cross.SetActive(false);
        Heart.SetActive(false);
        Square.SetActive(false);
        Star.SetActive(false);
        Triangle.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            AlterShape();
        }
    }
}
