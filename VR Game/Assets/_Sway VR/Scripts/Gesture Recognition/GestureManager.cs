using UnityEngine;
using System;


[RequireComponent(typeof(GestureReader))]
public class GestureManager : MonoBehaviour
{
    public GestureDataSO[] GestureLibrary;
    //The gesture that is targeted for adjustment
    public GestureDataSO currentDebugGesture;

    public GestureReader gestureReader;
    //Event that all scripts that get GestureInput are subscribed to
    public static event Action<GestureDataSO> OnGestureIdentified;

    
    private void Start()
    {
        OnGestureIdentified += GestureIdentifiedEventCalled;
        gestureReader = GetComponent<GestureReader>();
        
    }

    private void Update()
    {
        //Update the gesture for debug visuals and the target for being updated
        gestureReader.currentGesture = currentDebugGesture;
        foreach (GestureDataSO pose in GestureLibrary)
        {
            if(gestureReader.CheckGesture(pose))
            {
                //Broadcast the gesture found to all listeners that are subscribed to identitfy
                OnGestureIdentified?.Invoke(pose);
            }
        }
    }


    void GestureIdentifiedEventCalled(GestureDataSO gestureData)
    {
        Debug.Log("GestureIdentified: " + gestureData.name);
    }
}
