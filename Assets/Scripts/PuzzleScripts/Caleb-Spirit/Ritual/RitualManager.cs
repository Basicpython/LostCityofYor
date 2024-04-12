using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RitualManager : MonoBehaviour {

    private int radialDegree;
    private float radialRadius;
    private int radialSpeed;
    private int peripheralDegree;
    private float peripheralRadius;
    private int peripheralSpeed;

    //RitualStartAnimator ritualAnimation;
    PolygonSpawner polygonSpawner;

    public TextMeshProUGUI tmpComponent;

    public bool completed;

    // Start is called before the first frame update
    void Start()
    {
        //ritualAnimation = GetComponent<RitualStartAnimator>();
        polygonSpawner = GetComponent<PolygonSpawner>();

        //polygonSpawner.SpawnPolygon(3, 2f,  10, 3,  1f,  20 );
        //polygonSpawner.SpawnPolygon(7, 1.5f, 5, 7, 1.5f, 12);
        //polygonSpawner.SpawnPolygon(5, 0.5f, -21, 6, 1.5f, 25);

        radialDegree = 5;
        radialRadius = 0.5f;
        radialSpeed = -21;
        peripheralDegree = 6;
        peripheralRadius = 1.5f;
        peripheralSpeed = 25;

        tmpComponent.text = $"R(D:{radialDegree}, R:{radialRadius}, S:{radialSpeed}), P(D:{peripheralDegree}, R:{peripheralRadius}, S:{peripheralSpeed})";

        completed = false;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Spirit.instance.State != PuzzleStateType.Dialogue4) {
    //         return;//
    //     }
    //     if (!ritualAnimation.isActive) {
    //         ritualAnimation.StartRitual();
    //     }
    // }

    public void ChangeRadialDegree(int deltaRadialDegre) {
        radialDegree += deltaRadialDegre;
        //radialDegree = Mathf.Round(radialDegree);
        Debug.Log($"radialDegree = {radialDegree}");
    }

    public void ChangeRadialRadius(float deltaRadialRadius) {
        radialRadius += deltaRadialRadius;
        radialRadius = Mathf.Round(radialRadius * 10f) / 10f;
        Debug.Log($"radialRadius = {radialRadius}");
    }

    public void ChangeRadialSpeed(int deltaRadialSpeed) {
        radialSpeed += deltaRadialSpeed;
        //radialSpeed = Mathf.Round(radialSpeed);
        Debug.Log($"radialSpeed = {radialSpeed}");
    }

    public void ChangePeripheralDegree(int deltaPeripheralDegree) {
        peripheralDegree += deltaPeripheralDegree;
        //peripheralDegree = Mathf.Round(peripheralDegree);
        Debug.Log($"peripheralDegree = {peripheralDegree}");
    }

    public void ChangePeripheralRadius(float deltaPeripheralRadius) {
        peripheralRadius += deltaPeripheralRadius;
        peripheralRadius = Mathf.Round(peripheralRadius * 10f) / 10;
        Debug.Log($"peripheralRadius = {peripheralRadius}");
    }

    public void ChangePeripheralSpeed(int deltaPeripheralSpeed) {
        peripheralSpeed += deltaPeripheralSpeed;
        //peripheralSpeed = Mathf.Round(peripheralSpeed);
        Debug.Log($"peripheralSpeed = {peripheralSpeed}");
    }

    public void SpawnRitual() {
        polygonSpawner.SpawnPolygon(radialDegree, radialRadius, radialSpeed, peripheralDegree, peripheralRadius, peripheralSpeed);
        tmpComponent.text = $"R(D:{radialDegree}, R:{radialRadius}, S:{radialSpeed}), P(D:{peripheralDegree}, R:{peripheralRadius}, S:{peripheralSpeed})";
        if (radialDegree == 7 & radialRadius == 1.5 & radialSpeed == 5 & peripheralDegree == 7 & peripheralRadius == 1.5 & peripheralSpeed == 12) {
            if (!completed) {
                completed = true;
                GameManager.instance.NextState();
            }
        }
    }
}
