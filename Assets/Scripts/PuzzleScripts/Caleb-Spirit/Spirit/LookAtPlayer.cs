using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {
    public Transform playerTransform; // Reference to the player's transform
    public float rotationSpeed = 5f; // Speed of rotation
    public float lagFactor = 0.5f; // Lag factor (0: no lag, 1: full lag)

    private Quaternion targetRotation;

    // Update is called once per frame
    void Update() {
        if (playerTransform != null) {
            // Get the direction from this object to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Calculate the target rotation to look at the player
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly interpolate between the current rotation and the target rotation with lag
            targetRotation = Quaternion.Lerp(transform.rotation, lookRotation, lagFactor * Time.deltaTime * rotationSpeed);

            // Apply the interpolated rotation to the object
            transform.rotation = targetRotation;
        }
    }
}
