using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f;  // How long the bullet exists before being destroyed

    void Start()
    {
        // Destroy the bullet after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }
}
