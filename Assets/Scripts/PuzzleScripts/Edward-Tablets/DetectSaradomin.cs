using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSaradomin : MonoBehaviour
{
    public TabletManager tabletManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SaradominTablet")
        {
            tabletManager.saradominPlacedCorrect = true;
            tabletManager.saradominPlaced = true;
        }
        else
        {
            tabletManager.saradominPlacedCorrect = false;
            tabletManager.saradominPlaced = true;
        }
    }

    // Tablet Removed, Reset to False
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SaradominTablet"))
        {
            tabletManager.saradominPlacedCorrect = false;
            tabletManager.saradominPlaced = false;
        }
    }
}
