using UnityEngine;

public class Target : MonoBehaviour
{
    public bool isGreen = true;  // If true, it's a green element; if false, it's a red element

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (isGreen)
            {
                // Increase points
                GameManager.Instance.AddPoints(1);
            }
            else
            {
                // Decrease points
                GameManager.Instance.AddPoints(-1);
            }

            // Destroy the target after being hit
            Destroy(gameObject);
        }
    }
}
