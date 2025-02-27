using UnityEngine;
using System;
using System.Collections.Generic;


public struct InputState
{

    
    public bool activeThisFrame, activeLastFrame;

    bool InputStart()
    {
        return activeThisFrame && !activeLastFrame;
    }

    bool InputGoing()
    {
        return activeThisFrame && activeLastFrame;
    }
    bool InputEnd()
    {
        return !activeThisFrame && activeLastFrame;
    }
}

[RequireComponent(typeof(GestureReader))]
public class GestureManager : MonoBehaviour
{
    public GestureDataSO[] gestureLibrary;
   

    //public InputState[] gestureStates;

    [SerializeField] Dictionary<GestureDataSO, InputState> gestureActiveStates  = new Dictionary<GestureDataSO, InputState>();
    //The gesture that is targeted for adjustment
    public GestureDataSO currentDebugGesture;

    public GestureReader gestureReader;
    //Event that all scripts that get GestureInput are subscribed to
    public static event Action<GestureDataSO> OnGestureStarted;
    public static event Action<GestureDataSO> OnGestureActive;
    public static event Action<GestureDataSO> OnGestureExit;

    
    private void Start()
    {
        OnGestureStarted += GestureStartedEventCalled;
        OnGestureActive += GestureContinuedEventCalled;
        OnGestureExit += GestureEndedEventCalled;


        gestureReader = GetComponent<GestureReader>();
        
        /*for(int i = 0; i < gestureLibrary.Length; i++)
        {
            gestureActiveStates.Add(gestureLibrary[i], new InputState());
        }*/
    }
    
    private void Update()
    {
        //Update the gesture for debug visuals and the target for being updated
        gestureReader.debuggingGesture = currentDebugGesture;
        /*foreach (GestureDataSO pose in gestureLibrary)
        {
            if (gestureReader.CheckGesture(pose))
            {
                
                InputState updatedInputState = gestureActiveStates[pose];

                updatedInputState.activeLastFrame = updatedInputState.activeThisFrame;
                updatedInputState.activeThisFrame = true;
                //Broadcast the gesture found to all listeners that are subscribed to identitfy

                
                OnGestureStarted?.Invoke(pose);
            }
        }*/

        foreach (GestureDataSO pose in gestureLibrary)
        {
            gestureReader.UpdateGestureState(pose);
            if (gestureReader.GetGestureState(pose).inactive)
            {
                continue;
            }
            else if (gestureReader.GetGestureState(pose).started)
            {
                OnGestureStarted?.Invoke(pose);
            }
            else if (gestureReader.GetGestureState(pose).continued)
            {
                OnGestureActive?.Invoke(pose);
            }
            else if (gestureReader.GetGestureState(pose).ended)
            {
                OnGestureExit?.Invoke(pose);
            }
            


        }
    }


    void GestureStartedEventCalled(GestureDataSO gestureData)
    {
        Debug.Log("GestureStarted: " + gestureData.name);
    }
    void GestureContinuedEventCalled(GestureDataSO gestureData)
    {
        Debug.Log("GestureContinued: " + gestureData.name);
    }

    void GestureEndedEventCalled(GestureDataSO gestureData)
    {
        Debug.Log("GestureEnded: " + gestureData.name);
    }
}
