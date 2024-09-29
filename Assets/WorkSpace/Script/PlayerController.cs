using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    [System.Obsolete]
    void Update()
    {
        Vector2 vectorL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Vector2 vectorR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

        Vector3 changePosition = new Vector3(vectorL.x, 0, vectorL.y);
        Vector3 changeRotation = new Vector3(0, InputTracking.GetLocalRotation(XRNode.Head).eulerAngles.y, 0);

        //this.transform.position += this.transform.rotation * (Quaternion.Euler(changeRotation) * changePosition) * Time.deltaTime * SPEED_ADJUSTMENT;
        this.transform.Rotate(0, vectorR.x, 0);
    }
}