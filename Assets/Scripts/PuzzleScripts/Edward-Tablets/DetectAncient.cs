using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAncient : MonoBehaviour
{
    public TabletManager tabletManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AncientTablet")
        {
            tabletManager.ancientPlacedCorrect = true;
            tabletManager.ancientPlaced = true;
        }
        else
        {
            tabletManager.ancientPlacedCorrect = false;
            tabletManager.ancientPlaced = true;
        }
    }

    // Tablet Removed, Reset to False
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AncientTablet"))
        {
            tabletManager.ancientPlacedCorrect = false;
            tabletManager.ancientPlaced = false;
        }
    }
}
