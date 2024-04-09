using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualManager : MonoBehaviour {

    // private int radialDegree;
    // private int peripheralDegree;

    //RitualStartAnimator ritualAnimation;
    PolygonSpawner polygonSpawner;

    // Start is called before the first frame update
    void Start()
    {
        //ritualAnimation = GetComponent<RitualStartAnimator>();
        polygonSpawner = GetComponent<PolygonSpawner>();
        polygonSpawner.SpawnPolygon(5,   3,  12, 3,  1,  20 );
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
}
