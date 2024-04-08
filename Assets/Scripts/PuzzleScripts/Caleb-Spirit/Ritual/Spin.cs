using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 60f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the object around its up axis (Y-axis) over time
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
