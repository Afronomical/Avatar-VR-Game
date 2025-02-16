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
    //virtual VRDeviceType vrDeviceType;

    // The XR representation of the current device's type.
    // Note: Since it cannot be null it will be defaulted to the Head Mounted Device
    protected XRNode currentDeviceType = XRNode.Head;

    //A reference to the literal input device
    protected InputDevice device;


    //Device position, rotation, velocity and angular-velocity respectively
    protected Vector3 devPos;
    protected Quaternion devRot;
    protected Vector3 devVel;
    protected Vector3 devAngVel;




    protected virtual void Start()
    {
        SetupDevice();
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        FindDeviceIfLost();
    }




    #region Manage Device
    public bool IsDeviceNull()
    {
        bool devNull = !device.isValid;
        //Debug.Assert(devNull,"VR Input Device returned as null");  
        return devNull; 
    }
    private void FindDeviceIfLost()
    {
        if(IsDeviceNull()) { SetupDevice(); }; 
    }
    private void SetupDevice()
    {
        device = InputDevices.GetDeviceAtXRNode(currentDeviceType);
    }
    #endregion

    #region General Transform Data
    public Vector3 GetDevicePosition()
    {

        device.TryGetFeatureValue(CommonUsages.devicePosition, out devPos);

        return devPos;
    }
    public Quaternion GetDeviceRotation()
    {
        device.TryGetFeatureValue(CommonUsages.deviceRotation, out devRot);

        return devRot;
    }

    public Vector3 GetDeviceVelocity()
    {
        device.TryGetFeatureValue(CommonUsages.deviceVelocity, out devVel);

        return devVel;
    }
    public Vector3 GetAngularVelocity()
    {
        device.TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out devVel);

        return devAngVel;
    }
    #endregion


}
