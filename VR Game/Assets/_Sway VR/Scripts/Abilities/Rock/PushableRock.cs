using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PushableRock : MonoBehaviour
{

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push(Vector3 directionToLaunch, float force)
    {
        rb.AddForce(directionToLaunch * force);
        Debug.Log("launched rock");
    }
}
