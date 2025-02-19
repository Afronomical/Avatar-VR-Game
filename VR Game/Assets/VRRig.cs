using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;


    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}
public class VRRig : MonoBehaviour
{
    public Transform headConstraint;
    private Vector3 headBodyOffset;

    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public VRMap leftHint;
    public VRMap rightHint;

    private void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    private void LateUpdate()
    {
        transform.position = headConstraint.position + headBodyOffset;

        transform.forward = Vector3.ProjectOnPlane(headConstraint.forward,Vector3.up).normalized;

        head.Map();
        leftHand.Map();
        rightHand.Map();
        leftHint.Map();
        rightHint.Map();
    }
}
