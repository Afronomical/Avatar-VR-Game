using UnityEngine;


public class SummonRock : MonoBehaviour
{

    [SerializeField] GestureReader gestureRead;

    [SerializeField] GameObject objectToSpawn;


    Vector3 offset = new Vector3(0, 0, 5);
    Quaternion offsetRot = new Quaternion(0, 0, 0, 0);

    GameObject lastCreatedObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
