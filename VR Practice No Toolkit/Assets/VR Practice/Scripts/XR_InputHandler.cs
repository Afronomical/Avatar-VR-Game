using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class XR_InputHandler : MonoBehaviour
{
    private UnityEngine.XR.InputDevice devHead;
    private UnityEngine.XR.InputDevice devRightHand;
    private UnityEngine.XR.InputDevice devLeftHand;
    List<InputFeatureUsage> featureUsages;

    [SerializeField] InputAction inputAction;
    private void Start()
    {
        devLeftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        devRightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (devHead != null) { devHead = InputDevices.GetDeviceAtXRNode(XRNode.Head); };
        if (devLeftHand != null) { devLeftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand); };
        if (devRightHand != null) { devRightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand); };

    }
}
