using UnityEngine;

[CreateAssetMenu(fileName = "GestureDataSO", menuName = "Scriptable Objects/GestureDataSO")]
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

    [HideInInspector] public bool activeThisFrame;
    [HideInInspector] public bool activeLastFrame;
}
