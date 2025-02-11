using UnityEngine;
using UnityEngine.XR;


public class VR_HandInput : XR_InputHandler
{
    Vector2 joystickVal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region Input Data

    private Vector2 GetDeviceJoystickData()
    {

        //Check if Device is a controller with Joysticks
        if (currentDeviceType != XRNode.GameController) { Debug.LogError(); return; }

        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickVal);

        return joystickVal;
    }
    private void UpdateDeviceButtons()
    {


        //Check if Device is a controller with buttons
        if (currentDeviceType != XRNode.GameController) { return; }

        device.TryGetFeatureUsages(CommonUsages.grip)

    }
    #endregion
}
