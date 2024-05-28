using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f; // Speed at which the capsule rotates to face the movement direction

    private Rigidbody rb;

    public GameObject Sparks; // Reference to the particle system prefab

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Freeze rotation on the X and Z axes to prevent the capsule from tipping over
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Get input from the WASD keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a vector for the movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement.magnitude > 0.1f)
        {
            // Apply the movement to the Rigidbody, maintaining the current Y velocity to avoid unintended vertical movement
            Vector3 newVelocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);
            rb.velocity = newVelocity;

            // Calculate the direction to face based on the movement vector
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            // Smoothly rotate towards the target direction
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // If there's no input, stop the movement
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collisions with puddles
        if (collision.gameObject.CompareTag("Puddle"))
        {
            // Access the GameManager to update the contact count
            GameManager.Instance.PuddleCounter();
            // Destroy the puddle to simulate cleaning
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.Instance.WallCounter();
            // Get the point of contact
            ContactPoint contact = collision.contacts[0];
            // Instantiate the particle system at the point of contact
            Instantiate(Sparks, contact.point, Quaternion.identity);
        }
    }
}
