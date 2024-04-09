using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonSpawner : MonoBehaviour
{
    public GameObject prefab;

    private GameObject ritualObject;
    private Transform ritualTransform;

    void Start() {
        ritualObject = GameObject.Find("Orbitals");
        ritualTransform = ritualObject.transform;
    }

    public void SpawnPolygon(int radialDegree, float radialRadius, int radialSpeed, int peripheralDegree, float peripheralRadius, int peripheralSpeed) {
        // Destroy previously instantiated polygon
        DestroyPreviousPolygon();

        // Calculate the angle increment
        float radialAngleIncrement = 2f * Mathf.PI / radialDegree;

        // Iterate through each object
        for (int i = 0; i < radialDegree; i++) {
            // Calculate angle for the ith object
            float radialAngle = i * radialAngleIncrement;

            // Calculate the Carcesion coordinates
            float a = radialRadius * Mathf.Cos(radialAngle);
            float b = radialRadius * Mathf.Sin(radialAngle);
            
            // Create the parent object
            GameObject parentObject = new GameObject("Parent_" + i);

            ///////////
            
            // Calculate the angle increment
            float peripheralAngleIncrement = 2f * Mathf.PI / peripheralDegree;

            // Iterate through each object
            for (int j = 0; j < peripheralDegree; j++) {
                // Calculate angle for the ith object
                float peripheralAngle = j * peripheralAngleIncrement;

                // Calculate the Cartesion coordinates
                float x = peripheralRadius * Mathf.Cos(peripheralAngle);
                float y = peripheralRadius * Mathf.Sin(peripheralAngle);

                // Instantiate the object at the calculated position
                GameObject childObject = Instantiate(prefab, new Vector3(x, 0f, y), Quaternion.Euler(0,0,0));
                
                // Name the child object
                childObject.name = "Child_" + j;

                // Set the child's parent
                childObject.transform.SetParent(parentObject.transform);

                // Set the transform's position
                childObject.transform.position = new Vector3(x, 0f, y);

                // Set the transform's rotation
                childObject.transform.rotation = Quaternion.Euler(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360));

                // Set the transform's scale
                childObject.transform.localScale = new Vector3(10f, 10f, 10f);
            }

            // Set the parent's parent
            parentObject.transform.SetParent(ritualTransform);

            // Set the transform's position
            parentObject.transform.position = ritualTransform.transform.position + new Vector3(a, 0f, b);

            // Set the transform's rotation
            parentObject.transform.rotation = Quaternion.Euler(0f, radialAngle * -Mathf.Rad2Deg, 0f);

            // Set the transform's scale
            parentObject.transform.localScale = new Vector3(1f, 1f, 1f);

            // SPIN WEEEEE
            Spin peripheralSpin = parentObject.AddComponent<Spin>();

            // Peripheral spin speed
            peripheralSpin.rotationSpeed = peripheralSpeed;
        }

        // SPIN WEEEEE
        Spin RadialSpin = ritualObject.AddComponent<Spin>();

        // Radial spin speed
        RadialSpin.rotationSpeed = radialSpeed;
    }

    private void DestroyPreviousPolygon() {
        foreach (Transform child in ritualTransform.transform) {
            Destroy(child.gameObject); // destroy the child >:)
        }
    }
}

// rd   rr  rs  pd  pr  ps
// 5,   1.5,12, 3,  0.5,20 
// 7,   2,  12, 7,  2,  5
// 7,   2,  5,  7,  2,  12

