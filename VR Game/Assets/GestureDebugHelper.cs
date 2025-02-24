using UnityEngine;

public class GestureDebugHelper : MonoBehaviour
{

    

    [SerializeField]MeshRenderer leftPositionSphere, rightPositionSphere, leftRotationSphere, rightRotationSphere;

    public GestureManager manager;

    [SerializeField]Material trueMat, falseMat;

    public GestureDataSO currentGestureData;

    public GameObject gestureDisplay;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //manager = GetComponent<GestureManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRight();
        CheckLeft();

    }

    private void CheckLeft()
    {
        if (manager.isLeftPosTrue)
        {
            leftPositionSphere.material = trueMat;
        }
        else if (!manager.isLeftPosTrue)
        {
            leftPositionSphere.material = falseMat;
        }
        if (manager.isLeftRotTrue)
        {
            leftRotationSphere.material = trueMat;
        }
        else if (!manager.isLeftRotTrue)
        {
            leftRotationSphere.material = falseMat;
        }
    }

    private void CheckRight()
    {
        if (manager.isRightPosTrue)
        {
            rightPositionSphere.material = trueMat;
        }
        else if (!manager.isRightPosTrue)
        {
            rightPositionSphere.material = falseMat;
        }
        if (manager.isRightRotTrue)
        {

            rightRotationSphere.material = trueMat;
        }
        else if (!manager.isRightRotTrue)
        {

            rightRotationSphere.material = falseMat;
        }
    }
}
