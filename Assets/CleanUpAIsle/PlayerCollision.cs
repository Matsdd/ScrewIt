using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Define a delegate for collision events
    public delegate void OnCollisionEnterDelegate(Collision collision);
    // Define an event based on the delegate
    public static event OnCollisionEnterDelegate OnCollisionEnterEvent;

    void OnCollisionEnter(Collision collision)
    {
        // Invoke the collision event when a collision occurs
        OnCollisionEnterEvent?.Invoke(collision);
    }
}
