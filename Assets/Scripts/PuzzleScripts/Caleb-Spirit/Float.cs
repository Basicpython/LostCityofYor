using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float amplitude = 1f; // Amplitude of the sinusoidal motion
    public float frequency = 1f; // Frequency of the sinusoidal motion

    private Vector3 initialPosition; // Initial position of the object

    void Start() {
        // Store the initial position of the object
        initialPosition = transform.localPosition;
    }

    void Update() {
        // Calculate the vertical displacement using the sine function
        float verticalDisplacement = amplitude * Mathf.Sin(Time.time * frequency);

        // Update the object's position based on the sinusoidal motion
        transform.localPosition = initialPosition + new Vector3(0f, verticalDisplacement, 0f);
    }
}
