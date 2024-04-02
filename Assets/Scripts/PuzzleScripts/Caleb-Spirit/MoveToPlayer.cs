using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour {
    public Transform playerTransform; // Reference to the player's transform
    public float movementSpeed = 5f; // Speed of movement
    public float lagFactor = 0.5f; // Lag factor (0: no lag, 1: full lag)
    public float radius = 10f; // Closest distance to the player

    private void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the direction from this object to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Calculate the distance to the player
            float distanceToPlayer = directionToPlayer.magnitude;

            // Check if the object is outside the set radius
            if (distanceToPlayer > radius)
            {
                // Calculate the interpolation factor based on the distance ratio
                float t = Mathf.Clamp01((distanceToPlayer - radius) / (radius * 0.5f)); // Adjust 0.5f to control the rate of interpolation

                // Smoothly interpolate between the current position and the target position with lag
                Vector3 newPosition = Vector3.Lerp(transform.position, playerTransform.position, t * lagFactor * Time.deltaTime * movementSpeed);

                // Move the object towards the player
                transform.position = newPosition;
            }
        }
    }
}
