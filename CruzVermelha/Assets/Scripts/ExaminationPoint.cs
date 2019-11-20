using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminationPoint : MonoBehaviour
{
    public float cameraSize = 1f;
    public Vector2 cameraPosition;

    public void FocusOnPoint()
    {
        CameraFocus.FocusOnPositionWithSize(new Vector3(cameraPosition.x, cameraPosition.y, -10), cameraSize);
    }
}
