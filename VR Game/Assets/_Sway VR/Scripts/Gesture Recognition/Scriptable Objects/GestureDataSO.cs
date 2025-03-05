using UnityEngine;

[CreateAssetMenu(fileName = "GestureDataSO", menuName = "Gesture/GestureDataSO")]
public class GestureDataSO : ScriptableObject
{
    public string GestureName;

    public Vector3 lPosition;
    public Quaternion lRotation;

    public float lPositionThreshold = 0.3f;
    public float lRotationThreshold = 30.0f;

    public Vector3 rPosition;
    public Quaternion rRotation;

    public float rPositionThreshold = 0.3f;
    public float rRotationThreshold = 30.0f;

    public float rVelocity = 0.1f;
    public float lVelocity = 0.1f;


    [HideInInspector] public bool activeThisFrame;
    [HideInInspector] public bool activeLastFrame;
}
