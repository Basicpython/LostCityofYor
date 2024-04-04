using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGuthix : MonoBehaviour
{
    public TabletManager tabletManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GuthixTablet")
        {
            tabletManager.guthixPlacedCorrect = true;
            tabletManager.guthixPlaced = true;
        }
        else
        {
            tabletManager.guthixPlacedCorrect = false;
            tabletManager.guthixPlaced = true;
        }
    }

    // Tablet Removed, Reset to False
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GuthixTablet"))
        {
            tabletManager.guthixPlacedCorrect = false;
            tabletManager.guthixPlaced = false;
        }
    }
}
