using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lookSensitivity;
    public float mixXLook;
    public float maxXLook;
    public Transform camAnchor;

    public bool invertXRotation;

    private float curXRot;

    private void LateUpdate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        if (invertXRotation)
            y = -y;

        camAnchor.eulerAngles += Vector3.up * x * lookSensitivity;

        curXRot += y * lookSensitivity;
        curXRot = Mathf.Clamp(curXRot, mixXLook, maxXLook);

        Vector3 clampedAngle = camAnchor.eulerAngles;

        clampedAngle.x = curXRot;

        camAnchor.eulerAngles = clampedAngle;


    }
}
