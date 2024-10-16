using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;       // The bullet prefab
    public Transform firePoint;           // The point from which the bullets will be fired
    public float bulletSpeed = 20f;       // Speed of the bullet
    public Camera playerCamera;           // Reference to the player's camera

    void Update()
    {
        // Check if the player presses the fire button (usually the left mouse button)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Raycast from the center of the screen (crosshair direction)
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        // Check if the ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;  // Where the ray hit
        }
        else
        {
            // If the ray hits nothing, shoot in the direction the camera is facing
            targetPoint = ray.GetPoint(100);  // Arbitrary large distance
        }

        // Calculate the direction from the fire point to the target point
        Vector3 direction = targetPoint - firePoint.position;
        direction.Normalize();  // Normalize to get the direction only

        // Instantiate the bullet and set its velocity towards the target
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = direction * bulletSpeed;
    }
}
