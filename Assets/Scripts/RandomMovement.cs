using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 2f;           // Speed of movement
    public float changeDirectionTime = 2f; // Time interval for changing direction

    public Vector2 movementAreaMin;        // Minimum X, Z coordinates for movement
    public Vector2 movementAreaMax;        // Maximum X, Z coordinates for movement

    private Vector3 randomDirection;       // The current direction of movement

    void Start()
    {
        // Start with a random direction and change direction at regular intervals
        ChooseRandomDirection();
        InvokeRepeating("ChooseRandomDirection", changeDirectionTime, changeDirectionTime);
    }

    void Update()
    {
        // Move the element in the chosen random direction
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime, Space.World);

        // Check if the element is out of bounds and keep it within the defined area
        ConstrainPosition();
    }

    // Choose a new random direction for the element to move in
    void ChooseRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        randomDirection = new Vector3(randomX, 0, randomZ).normalized;
    }

    // Constrain the element's position to stay within the defined area
    void ConstrainPosition()
    {
        Vector3 currentPosition = transform.position;

        // Clamp the X and Z positions to keep the element within the boundaries
        float clampedX = Mathf.Clamp(currentPosition.x, movementAreaMin.x, movementAreaMax.x);
        float clampedZ = Mathf.Clamp(currentPosition.z, movementAreaMin.y, movementAreaMax.y);

        // Apply the clamped position to the element
        transform.position = new Vector3(clampedX, currentPosition.y, clampedZ);
    }
}
