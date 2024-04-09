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

    // Start is called before the first frame update
    void Start()
    {
        //ritualAnimation = GetComponent<RitualStartAnimator>();
        polygonSpawner = GetComponent<PolygonSpawner>();
        // polygonSpawner.SpawnPolygon(5,   3,  12, 3,  1,  20 );

        radialDegree = 5;
        radialRadius = 3f;
        radialSpeed = 12;
        peripheralDegree = 3;
        peripheralRadius = 1f;
        peripheralSpeed = 20;
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
        Debug.Log($"radialDegree = {radialDegree}");
    }

    public void ChangeRadialRadius(float deltaRadialRadius) {
        radialRadius += deltaRadialRadius;
        Debug.Log($"radialRadius = {radialRadius}");
    }

    public void ChangeRadialSpeed(int deltaRadialSpeed) {
        radialSpeed += deltaRadialSpeed;
        Debug.Log($"radialSpeed = {radialSpeed}");
    }

    public void ChangePeripheralDegree(int deltaPeripheralDegree) {
        peripheralDegree += deltaPeripheralDegree;
        Debug.Log($"peripheralDegree = {peripheralDegree}");
    }

    public void ChangePeripheralRadius(float deltaPeripheralRadius) {
        peripheralRadius += deltaPeripheralRadius;
        Debug.Log($"peripheralRadius = {peripheralRadius}");
    }

    public void ChangePeripheralSpeed(int deltaPeripheralSpeed) {
        peripheralSpeed += deltaPeripheralSpeed;
        Debug.Log($"peripheralSpeed = {peripheralSpeed}");
    }

    public void SpawnRitual() {
        polygonSpawner.SpawnPolygon(radialDegree, radialRadius, radialSpeed, peripheralDegree, peripheralRadius, peripheralSpeed);
        tmpComponent.text = $"R(D:{radialDegree}, R:{radialRadius}, S:{radialSpeed}), P(D:{peripheralDegree}, R:{peripheralRadius}, S:{peripheralSpeed})";
    }
}
