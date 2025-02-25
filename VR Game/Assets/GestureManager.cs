using UnityEngine;
using System;


[RequireComponent(typeof(GestureReader))]
public class GestureManager : MonoBehaviour
{
    public GestureDataSO[] GestureLibrary;

    [SerializeField] GestureReader gestureReader;
    public static event Action<GestureDataSO> OnGestureIdentified;


    private void Start()
    {
        OnGestureIdentified += GestureIdentifiedEventCalled;
        gestureReader = GetComponent<GestureReader>();
    }

    private void Update()
    {
        foreach (GestureDataSO pose in GestureLibrary)
        {
            if(gestureReader.CheckGesture(pose))
            {
                OnGestureIdentified?.Invoke(pose);
            }
        }
    }


    void GestureIdentifiedEventCalled(GestureDataSO gestureData)
    {
        Debug.Log("GestureIdentified: " + gestureData.name);
    }
}
