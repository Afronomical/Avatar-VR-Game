using NUnit.Framework;

using UnityEngine;
using UnityEngine.XR;


public enum VRDeviceType
{
    //These are the Values of the Devices XRNode respectively

    //These will be used to select the device in this script.
    VRHead = 3,
    VRRightHand = 4,
    VRLeftHand = 5,
}

public class XR_InputHandler : MonoBehaviour
{

    //The Enumerated representation of the device type, to be set in the Editor. Changes the type of Input this script will record
    virtual VRDeviceType vrDeviceType;

    // The XR representation of the current device's type
    protected XRNode currentDeviceType = XRNode.Head;

    //A reference to the literal input device
    protected InputDevice device;



    protected Vector3 devPos;
    protected Quaternion devRot;
    protected Vector3 devVel;
    protected Vector3 devAngVel;




    void Start()
    {
        SetupDevice();
    }
    // Update is called once per frame
    void Update()
    {
        FindDeviceIfLost();
    }




    #region Manage Device
    private bool IsDeviceNull()
    {
        bool devNull = !device.isValid;
        Debug.Assert(devNull,"VR Input Device returned as null");  
        return devNull; 
    }
    private void FindDeviceIfLost()
    {
        if(IsDeviceNull()) { SetupDevice(); }; 
    }
    private void SetupDevice()
    {
        switch (vrDeviceType)
        {
            case VRDeviceType.VRHead:

                currentDeviceType = XRNode.Head;

                break;
            case VRDeviceType.VRRightHand:

                currentDeviceType = XRNode.RightHand;
                break;
            case VRDeviceType.VRLeftHand:

                currentDeviceType = XRNode.LeftHand;
                break;
            default:
                Debug.LogError("XRInputHandler SetupDevice: deviceType not set");
                break;
        }

        device = InputDevices.GetDeviceAtXRNode(currentDeviceType);
    }
    #endregion

    #region General Transform Data
    private Vector3 GetDevicePosition()
    {

        device.TryGetFeatureValue(CommonUsages.devicePosition, out devPos);

        return devPos;
    }
    private Quaternion GetDeviceRotation()
    {
        device.TryGetFeatureValue(CommonUsages.deviceRotation, out devRot);

        return devRot;
    }

    private Vector3 GetDeviceVelocity()
    {
        device.TryGetFeatureValue(CommonUsages.deviceVelocity, out devVel);

        return devVel;
    }
    private Vector3 GetAngularVelocity()
    {
        device.TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out devVel);

        return devAngVel;
    }
    #endregion


}
