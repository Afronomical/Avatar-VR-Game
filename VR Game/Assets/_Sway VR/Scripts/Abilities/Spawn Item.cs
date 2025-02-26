using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]GestureManager manager;

    [SerializeField]GestureDataSO gestureToActivate;

    [SerializeField]GameObject objectToSpawn;

    Vector3 offset = new Vector3(0, 0, 5);
    Quaternion offsetRot = new Quaternion(0,0,0,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        GestureManager.OnGestureIdentified += Spawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(GestureDataSO gestureData)
    {
        if(gestureData == gestureToActivate)
        {
            GestureReader gestureRead = manager.gestureReader;
            
            Instantiate(objectToSpawn, gestureRead.AdjustPositionToPlayer(offset), gestureRead.AdjustRotationToPlayer(offsetRot));
        }
    }
}
