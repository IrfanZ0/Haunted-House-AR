using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LightEstimation : MonoBehaviour
{
    public float? brightness;

    [SerializeField]
    private ARCameraManager aRCameraManager;

    

   void OnEnable()
   {
        if (aRCameraManager != null)
        {
            aRCameraManager.frameReceived += FrameChanged;
        }

   }

    private void FrameChanged(ARCameraFrameEventArgs obj)
    {
        if (obj.lightEstimation.averageBrightness.HasValue)
        {
            brightness = obj.lightEstimation.averageBrightness;
        }
    }

    void OnDisable()
   {
        if (aRCameraManager != null)
        {
            aRCameraManager.frameReceived -= FrameChanged;
        }
    }
}
