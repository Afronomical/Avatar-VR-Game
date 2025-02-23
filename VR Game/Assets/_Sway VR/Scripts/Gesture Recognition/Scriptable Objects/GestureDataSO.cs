using UnityEngine;

[CreateAssetMenu(fileName = "GestureDataSO", menuName = "Scriptable Objects/GestureDataSO")]
public class GestureDataSO : ScriptableObject
{
    string GestureName;

    public Vector3 lPosition;
    public Quaternion lRotation;

    public float lPositionThreshold;
    public float lRotationThreshold;

    public Vector3 rPosition;
    public Quaternion rRotation;

    public float rPositionThreshold;
    public float rRotationThreshold;
}
