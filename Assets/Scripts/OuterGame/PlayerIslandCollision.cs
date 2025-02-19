// A script used to handle player collisions with islands, shops, and rocks.

using UnityEngine;

public class PlayerIslandCollision : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Island" || tag == "Shop" || tag == "Rocks") // Check if the collision is with an island, shop, or rocks
        {
            Debug.Log($"Collision with {tag.ToLower()} detected!");
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // Stop the player's movement
            }
            Vector3 pushDirection = transform.position - collision.transform.position; 
            pushDirection.y = 0; // Ignore the y component
        }
    }
}
