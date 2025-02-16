using UnityEngine;

public class HandMove : MonoBehaviour
{
    [SerializeField]VR_HandInput targetInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(targetInput.GetDeviceVelocity());
        Debug.Log(targetInput.GetDeviceRotation());
    }
}
