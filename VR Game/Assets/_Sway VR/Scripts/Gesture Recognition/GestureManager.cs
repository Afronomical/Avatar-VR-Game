using UnityEngine;

public class GestureManager : MonoBehaviour
{

    [SerializeField] GameObject rightHand;
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject Head;

    [SerializeField] GestureDataSO gesture;

    [SerializeField] Vector3 gesturePos;
    
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Head.transform.InverseTransformPoint(rightHand.transform.position));

        gesturePos = Head.transform.position + Head.transform.right* gesture.rPosition.x + Head.transform.up * gesture.rPosition.y + Head.transform.forward * gesture.rPosition.z;

        if(CheckGesturePosInRange(rightHand.transform.position, gesturePos, gesture.rPositionThreshold))
        {
            Debug.Log("IN RANGE");
        }
        
    }


    bool CheckGesturePosInRange(Vector3 currentPosition, Vector3 gesturePosition, float posThreshold)
    {
        
        Debug.Log(Vector3.Distance(currentPosition, gesturePosition));
        return Vector3.Distance(currentPosition, gesturePosition) < posThreshold;
    }
    bool CheckGestureRotation(Quaternion currentRotation, Quaternion targetRotation, float rotThreshold)
    {
        return Quaternion.Dot(currentRotation, targetRotation) > rotThreshold;
    }

    void CalcWithinRange()
    {
        
    }
}
