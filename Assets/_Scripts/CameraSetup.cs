using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    void Start()
    {
        // Get the main camera
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Set the camera to orthographic mode
            mainCamera.orthographic = true;

            // Calculate the desired orthographic size based on your scene setup
            // Adjust this value according to your scene's needs
            float targetOrthographicSize = 5f;

            // Set the orthographic size
            mainCamera.orthographicSize = targetOrthographicSize;

            Screen.SetResolution(1920, 1080, true);
        }
        else
        {
            Debug.LogError("Main camera not found!");
        }
    }
}
