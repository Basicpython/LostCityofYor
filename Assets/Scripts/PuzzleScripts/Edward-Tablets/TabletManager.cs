using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TabletManager : MonoBehaviour
{
    public bool saradominPlacedCorrect;
    public bool zamorakPlacedCorrect;
    public bool guthixPlacedCorrect;
    public bool ancientPlacedCorrect;

    public bool saradominPlaced;
    public bool zamorakPlaced;
    public bool guthixPlaced;
    public bool ancientPlaced;

    // Variables to hold the tablet GameObjects
    public GameObject saradominTablet;
    public GameObject zamorakTablet;
    public GameObject guthixTablet;
    public GameObject ancientTablet;

    public GameObject symbol3;

    // Set default placement, correct placement
    private void Start()
    {
        saradominPlacedCorrect = false;
        zamorakPlacedCorrect = false;
        guthixPlacedCorrect = false;
        ancientPlacedCorrect = false;

        saradominPlaced = false;
        zamorakPlaced = false;
        guthixPlaced = false;
        ancientPlaced = false;

        symbol3.SetActive(false);
    }

    // Tablets are in the correct order if all placement flags are true
    private bool CheckTabletOrder()
    {
        return saradominPlacedCorrect && zamorakPlacedCorrect && guthixPlacedCorrect && ancientPlacedCorrect;
    }

    private void Update()
    {
        if (saradominPlaced && zamorakPlaced && guthixPlaced && ancientPlaced)
        {
            if (!CheckTabletOrder())
            {
                Debug.Log("Incorrect Order !!!");
                symbol3.SetActive(false);
            }
            else
            {
                Debug.Log("All Tablets Are In The Correct Spot !!!");
                GameManager.instance.NextState();
                symbol3.SetActive(true);
            }
        }
    }


   
}
