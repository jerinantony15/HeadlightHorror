using UnityEngine;

public class Carfollow : MonoBehaviour
{
    public Transform target;      
    public float distance = 8f;   
    public float height = 4f;     
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Rigidbody carRb = target.GetComponent<Rigidbody>();
        float directionMultiplier = 1f;
        float reverseThreshold = -0.1f; // only flip camera if moving backward significantly

        if (carRb != null && Vector3.Dot(target.forward, carRb.linearVelocity) < reverseThreshold)
        {
            directionMultiplier = -1f; // camera in front
        }

        // Keep camera upright
        Vector3 flatForward = Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized;

        // Desired camera position
        Vector3 desiredPosition = target.position
                                  - flatForward * distance * directionMultiplier
                                  + Vector3.up * height;

        // Smooth movement
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // Look at car, keep camera upright
        Vector3 lookPosition = target.position;
        lookPosition.y = transform.position.y;
        transform.LookAt(lookPosition);
    }
}