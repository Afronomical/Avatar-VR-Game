using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum VRSelectedHand
{
    //These are the Values of the Devices XRNode respectively

    //These will be used to select the device in this script.
    RightHand = 0,
    LeftHand = 1,
}

public enum VRButtonType
{
    Trigger,
    Grip,
    JoystickPress,
    Button1,
    Button2,

}
public struct ButtonState
{
    public bool lastFrame;
    public bool currentFrame;

    public bool isPressed() { return currentFrame && !lastFrame; }

    public bool isReleased() { return !currentFrame && lastFrame; }

    public bool isHeld() { return currentFrame && lastFrame; }
}

public class VR_HandInput : XR_InputHandler
{
    Vector2 joystickVal;

    [SerializeField] VRSelectedHand selectedHand;
    public VRSelectedHand GetWhichHand() { return selectedHand; }


    private Dictionary<VRButtonType, ButtonState> buttonStatesMap = new Dictionary<VRButtonType, ButtonState>();

    protected override void Start()
    {
        currentDeviceType = XRNode.RightHand;
        base.Start();
        
    }
    protected virtual void Update()
    {
        UpdateButtons();
    }
    #region Get Input Data

    public Vector2 GetDeviceJoystickData()
    {
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickVal);

        return joystickVal;
    }
    public bool ButtonPressed(VRButtonType btnPressed )
    {

        return buttonStatesMap[btnPressed].isPressed();

    }
    public bool ButtonHeld(VRButtonType btnPressed)
    {

        return buttonStatesMap[btnPressed].isHeld();

    }
    public bool ButtonReleased(VRButtonType btnPressed)
    {

        return buttonStatesMap[btnPressed].isReleased();

    }

    void UpdateButtonState(VRButtonType button, bool isPressed)
    {
        // Check if a button of this type is in the dictionary, if not add one
        if(!buttonStatesMap.ContainsKey(button))
        {
            buttonStatesMap[button] = new ButtonState { lastFrame = false, currentFrame = false};
        }
        
        ButtonState tempState = buttonStatesMap[button];
        tempState.lastFrame = tempState.currentFrame;
        tempState.currentFrame = isPressed;

        buttonStatesMap[button] = tempState;
    }
    void UpdateButtons()
    {

        bool btnPressed;
        device.TryGetFeatureValue(CommonUsages.gripButton, out btnPressed);
        UpdateButtonState(VRButtonType.Grip, btnPressed);

        device.TryGetFeatureValue(CommonUsages.triggerButton, out btnPressed);
        UpdateButtonState(VRButtonType.Trigger, btnPressed);
        
        device.TryGetFeatureValue(CommonUsages.primaryButton, out btnPressed);
        UpdateButtonState(VRButtonType.Button1, btnPressed);

        device.TryGetFeatureValue(CommonUsages.secondaryButton, out btnPressed);
        UpdateButtonState(VRButtonType.Button2, btnPressed);

        device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out btnPressed);
        UpdateButtonState(VRButtonType.JoystickPress, btnPressed);


    }

    
    #endregion
}
