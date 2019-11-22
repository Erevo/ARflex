using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using System.Collections.Generic;
using System.Linq;
public class CameraFocus : MonoBehaviour
{
    TrackableSettings trackableSettings;
    void Start()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
       // this.trackableSettings.ToggleDeviceTracking(enable);
    }
}
