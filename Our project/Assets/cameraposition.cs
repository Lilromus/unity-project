using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraHeight = 5.0f; // Set your desired height here

    void Start()
    {
        // Get the camera's transform component
        Transform cameraTransform = Camera.main.transform;

        // Set the new position with the desired height
        cameraTransform.position = new Vector3(cameraTransform.position.x, cameraHeight, cameraTransform.position.z);
    }
}
