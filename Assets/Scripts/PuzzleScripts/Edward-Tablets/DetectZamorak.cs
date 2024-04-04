using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZamorak : MonoBehaviour
{
    public TabletManager tabletManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ZamorakTablet")
        {
            tabletManager.zamorakPlacedCorrect = true;
            tabletManager.zamorakPlaced = true;
        }
        else
        {
            tabletManager.zamorakPlacedCorrect = false;
            tabletManager.zamorakPlaced = true;
        }
    }

    // Tablet Removed, Reset to False
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZamorakTablet"))
        {
            tabletManager.zamorakPlacedCorrect = false;
            tabletManager.zamorakPlaced = false;
        }
    }
}
