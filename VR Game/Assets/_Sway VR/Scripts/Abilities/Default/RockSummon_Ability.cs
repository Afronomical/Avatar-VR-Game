using UnityEngine;

public class RockSummon_Ability : Ability
{
    
    GameObject createdObject;

    Vector3 offset = new Vector3(0, 0, 5);
    Quaternion offsetRot = new Quaternion(0, 0, 0, 0);

    private void Start()
    {
        GestureManager.OnGestureStarted += CheckGesture;
    }
    void CheckGesture(GestureDataSO gesture)
    {
        if (gesture == requiredGestures[gestureIndex])
        {
            gestureIndex++;

            if (gestureIndex >= requiredGestures.Length)
            {
                //Complete Ability

                
            }

        }
        else if (gestureIndex != 0 && gesture == requiredGestures[0])
        {
            gestureIndex = 0;
        }
        else
        {

        }

    }


    void Spawn()
    {
        //createdObject = Instantiate(objectToSpawn, )
    }
}
