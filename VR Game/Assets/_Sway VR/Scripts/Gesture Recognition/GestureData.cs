using UnityEngine;

public class HandData
{
    Vector3 position;
    Quaternion rotation;

    float positionThreshold;
    float rotationThreshold;

    HandData(Vector3 position, Quaternion rotation, float positionThreshold, float rotationThreshold)
    {
        this.position = position;
        this.rotation = rotation;
        this.positionThreshold = positionThreshold;
        this.rotationThreshold = rotationThreshold;
    }
}

public class GestureData : MonoBehaviour
{
    HandData leftHand
    {
        get;
    }
    HandData rightHand
    {
        get;
    }

    GestureData(HandData leftHand, HandData rightHand)
    {
        this.leftHand = leftHand;
        this.rightHand = rightHand;
    }
}
