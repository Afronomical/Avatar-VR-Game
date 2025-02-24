using UnityEngine;

public class GestureManager : MonoBehaviour
{

    [SerializeField] GameObject rightHand;
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject Head;

    [SerializeField] GestureDataSO gesture;
    //[SerializeField] GestureLibrary gestureLibrary;

    [SerializeField] Vector3 rightGesturePos;
    [SerializeField] Quaternion rightGestureRotation;
    [SerializeField] Vector3 leftGesturePos;
    [SerializeField] Quaternion leftGestureRotation;
    public bool isLeftPosTrue; 
    public bool isLeftRotTrue;    
    public bool isRightPosTrue;    
    public bool isRightRotTrue;    

    // Update is called once per frame
    void Update()
    {

        if(CheckGesturePosInRange(rightHand.transform.position, AdjustPositionToPlayer(gesture.rPosition), gesture.rPositionThreshold))
        {
            
            isRightPosTrue = true;
        }
        else
        {
            isRightPosTrue = false;
        }
        if (CheckGestureRotation(rightHand.transform.rotation, AdjustRotationToPlayer(gesture.rRotation), gesture.rRotationThreshold))
        {
            isRightRotTrue = true;
        }
        else
        {
            isRightRotTrue = false;
        }
        
        if (CheckGesturePosInRange(leftHand.transform.position, AdjustPositionToPlayer(gesture.lPosition), gesture.lPositionThreshold))
        {
           
            isLeftPosTrue = true;
        }
        else
        {
            isLeftPosTrue = false;
        }
        if(CheckGestureRotation(leftHand.transform.rotation, AdjustRotationToPlayer(gesture.lRotation), gesture.lRotationThreshold))
        {
        
            isLeftRotTrue = true;
        }
        else
        {
            isLeftRotTrue= false;
        }

        if (CheckGesture(gesture))
        {
            Debug.Log("You are in balance");
        }

    }

    Vector3 AdjustPositionToPlayer(Vector3 offset)
    {
        return Head.transform.position + Head.transform.right * offset.x + Head.transform.up * offset.y + Head.transform.forward * offset.z;
        
    }
    Quaternion AdjustRotationToPlayer(Quaternion offset)
    {
        return Head.transform.rotation * offset;
    }
    public bool CheckGesturePosInRange(Vector3 currentPosition, Vector3 gesturePosition, float posThreshold)
    {
        
        //Debug.Log(Vector3.Distance(currentPosition, gesturePosition));
        return Vector3.Distance(currentPosition, gesturePosition) < posThreshold;
    }
    public bool CheckGestureRotation(Quaternion currentRotation, Quaternion targetRotation, float rotThreshold)
    {
        //Debug.Log(Quaternion.Dot(currentRotation, targetRotation));
        return (Mathf.Abs(Quaternion.Dot(currentRotation, targetRotation)) > rotThreshold);
    }

    public bool CheckGesture(GestureDataSO gesture)
    {
        return CheckGesturePosInRange(rightHand.transform.position, AdjustPositionToPlayer(gesture.rPosition), gesture.rPositionThreshold) &&
               CheckGestureRotation(rightHand.transform.rotation, AdjustRotationToPlayer(gesture.rRotation), gesture.rRotationThreshold) &&
               CheckGesturePosInRange(leftHand.transform.position, AdjustPositionToPlayer(gesture.lPosition), gesture.lPositionThreshold) &&
               CheckGestureRotation(leftHand.transform.rotation, AdjustRotationToPlayer(gesture.lRotation), gesture.lRotationThreshold);

    }
}
