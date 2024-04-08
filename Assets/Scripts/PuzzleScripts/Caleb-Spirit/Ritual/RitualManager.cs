using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualManager : MonoBehaviour
{
    RitualStartAnimator ritualAnimation;

    // Start is called before the first frame update
    void Start()
    {
        ritualAnimation = GetComponent<RitualStartAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Spirit.instance.State != PuzzleStateType.Dialogue4) {
            return;//
        }
        if (!ritualAnimation.isActive) {
            ritualAnimation.StartRitual();
        }
    }
}
