using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    float startingCameraSize;
    Vector3 startingPosition;
    [SerializeField]
    float lerpDuration;

    bool lerpCameraCoroutineIsOn = false;
    Coroutine lerpCameraCoroutine;

    [SerializeField]
    ControladorCamera controladorCamera;

    private static CameraFocus instance;
    public static CameraFocus Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CameraFocus>();
                if (instance == null)
                {
                    Debug.LogError("Missing CameraFocus in scene");
                }
            }
            return instance;
        }

    }




    void Start()
    {
        startingCameraSize = camera.orthographicSize;
        startingPosition = transform.localPosition;

        
    }

 

    public static void FocusOnPositionWithSize(Vector3 desiredPosition , float desiredSize)
    {
  
       
        Instance.FocusOnPositionWithSize_(desiredPosition, desiredSize);
    }

    private void FocusOnPositionWithSize_(Vector3 desiredPosition, float desiredSize)
    {
        if(lerpCameraCoroutineIsOn)
        {
            StopCoroutine(lerpCameraCoroutine);
        }
        lerpCameraCoroutine = StartCoroutine(CameraLerp(desiredPosition, desiredSize));
        
    }


    public static void BackToStartingPositionAndSize()
    {
        FocusOnPositionWithSize(Instance.startingPosition , Instance.startingCameraSize);
    }

    IEnumerator CameraLerp(Vector3 desiredPosition, float desiredSize)
    {

        lerpCameraCoroutineIsOn = true;
        Vector3 pastPosition = transform.localPosition;
        float pastCameraSize = camera.orthographicSize;
        float currentLerpTime = 0f;
        float currentFraction;

        while (currentLerpTime < lerpDuration)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpDuration)
            {
                currentLerpTime = lerpDuration;
            }
            currentFraction = currentLerpTime / lerpDuration;

            transform.localPosition = Vector3.Lerp(pastPosition, desiredPosition, currentFraction);
            camera.orthographicSize = Mathf.Lerp(pastCameraSize, desiredSize, currentFraction);

            yield return null;
        }
        lerpCameraCoroutineIsOn = false;
       
    }
}

