using UnityEngine;

public class GestureReader : MonoBehaviour
{

    [SerializeField] GameObject rightHand;
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject Head;

    public GestureDataSO currentGesture;

    [SerializeField] Vector3 rightGesturePos;
    [SerializeField] Quaternion rightGestureRotation;
    [SerializeField] Vector3 leftGesturePos;
    [SerializeField] Quaternion leftGestureRotation;
    
    public Transform GetHeadTransform()
    {
        Transform transf = Head.transform;
        return transf;
    }
    public Transform GetRightTransform()
    {
        Transform transf = transform;
        transf.position = Head.transform.InverseTransformPoint(rightHand.transform.position);

        transf.rotation = Quaternion.Inverse(Head.transform.rotation) * rightHand.transform.rotation;
        return transf;
    }
    public Transform GetLeftTransform()
    {

        Transform transf = transform;
        transf.position = Head.transform.InverseTransformPoint(leftHand.transform.position);

        transf.rotation = Quaternion.Inverse(Head.transform.rotation) * leftHand.transform.rotation;
        return transf;
    }
    public bool isLeftPosTrue; 
    public bool isLeftRotTrue;    
    public bool isRightPosTrue;    
    public bool isRightRotTrue;    

    // Update is called once per frame
    void Update()
    {
        DebugGesture();
    }


    public Vector3 AdjustPositionToPlayer(Vector3 offset)
    {
        //Adjusts offset based on players Y position.
        Quaternion yRotation = Quaternion.Euler(0, Head.transform.eulerAngles.y, 0);

       
        return Head.transform.position + yRotation * offset;
    }
    public Quaternion AdjustRotationToPlayer(Quaternion offset)
    {
        //Adjusts offset based on players rotation
        Quaternion yRotation = Quaternion.Euler(0, Head.transform.eulerAngles.y, 0);

        
        return yRotation * offset;
    }
    public bool CheckGesturePosInRange(Vector3 currentPosition, Vector3 gesturePosition, float posThreshold)
    {
        
        //True if distance is less than threshold. Obvious I think...
        return Vector3.Distance(currentPosition, gesturePosition) < posThreshold;
    }
    public bool CheckGestureRotation(Quaternion currentRotation, Quaternion targetRotation, float rotThreshold)
    {
        //True if the angle between them is less than threshold
        return (Quaternion.Angle(currentRotation, targetRotation) < rotThreshold);

        
    }

    public bool CheckGesture(GestureDataSO gesture)
    {
         //Checks the position and rotation of each hand along with a mirrored version

         //TODO: Make mirrored position flipped on Head.Forward axis

        //Check original right hand
        if (!CheckGesturePosInRange(rightHand.transform.position, AdjustPositionToPlayer(gesture.rPosition), gesture.rPositionThreshold) ||
            !CheckGestureRotation(rightHand.transform.rotation, AdjustRotationToPlayer(gesture.rRotation), gesture.rRotationThreshold))
        {
            //If the original right hand fails, check for a mirrored version
            if (!CheckGesturePosInRange(leftHand.transform.position, AdjustPositionToPlayer(gesture.rPosition), gesture.rPositionThreshold) ||
                !CheckGestureRotation(leftHand.transform.rotation, AdjustRotationToPlayer(gesture.rRotation), gesture.rRotationThreshold))
            {
                return false; //Exit if both original and mirrored right hand fail
            }
        }
        //Check original left hand
        if (!CheckGesturePosInRange(leftHand.transform.position, AdjustPositionToPlayer(gesture.lPosition), gesture.lPositionThreshold) ||
            !CheckGestureRotation(leftHand.transform.rotation, AdjustRotationToPlayer(gesture.lRotation), gesture.rRotationThreshold))
        {
            //If the original left hand fails, check for mirrored version
            if (!CheckGesturePosInRange(rightHand.transform.position, AdjustPositionToPlayer(gesture.lPosition), gesture.lPositionThreshold) ||
                !CheckGestureRotation(rightHand.transform.rotation, AdjustRotationToPlayer(gesture.lRotation), gesture.rRotationThreshold))
            {
                return false; 
            }
        }

        return true; // Gesture is valid if all checks pass

    }
    private void DebugGesture()
    {
     //Debug to chekc if   
        if (CheckGesturePosInRange(rightHand.transform.position, AdjustPositionToPlayer(currentGesture.rPosition), currentGesture.rPositionThreshold))
        {

            isRightPosTrue = true;
        }
        else
        {
            isRightPosTrue = false;
        }
        if (CheckGestureRotation(rightHand.transform.rotation, AdjustRotationToPlayer(currentGesture.rRotation), currentGesture.rRotationThreshold))
        {
            isRightRotTrue = true;
        }
        else
        {
            isRightRotTrue = false;
        }

        if (CheckGesturePosInRange(leftHand.transform.position, AdjustPositionToPlayer(currentGesture.lPosition), currentGesture.lPositionThreshold))
        {

            isLeftPosTrue = true;
        }
        else
        {
            isLeftPosTrue = false;
        }
        if (CheckGestureRotation(leftHand.transform.rotation, AdjustRotationToPlayer(currentGesture.lRotation), currentGesture.rRotationThreshold))
        {

            isLeftRotTrue = true;
        }
        else
        {
            isLeftRotTrue = false;
        }
    }
}
