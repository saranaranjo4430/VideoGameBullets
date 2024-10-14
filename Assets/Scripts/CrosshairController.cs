using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public GameObject crosshair;  // Reference to the crosshair object

    void Start()
    {
        // Optional: Start with the crosshair enabled or disabled
        crosshair.SetActive(true);
    }

    void Update()
    {
        // You can set up conditions to hide/show the crosshair
        // For example, when the player presses a key or enters an aiming mode
        if (Input.GetKeyDown(KeyCode.H))  // Example: Press 'H' to hide/show
        {
            crosshair.SetActive(!crosshair.activeSelf);
        }
    }
}
