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

    public GameObject saradominTablet;
    public GameObject zamorakTablet;
    public GameObject guthixTablet;
    public GameObject ancientTablet;

    public GameObject symbol3;

    public Transform saradominStartPosition;
    public Transform zamorakStartPosition;
    public Transform guthixStartPosition;
    public Transform ancientStartPosition;

    public SoundManager soundManager;

    private bool completed;

    private void Start()
    {
        saradominPlacedCorrect = false;
        zamorakPlacedCorrect = false;
        guthixPlacedCorrect = false;
        ancientPlacedCorrect = false;

        symbol3.SetActive(false);

        completed = false;
    }

    public void ResetTabletPosition(GameObject tablet)
    {
        if (tablet.CompareTag("SaradominTablet"))
        {
            tablet.transform.position = saradominStartPosition.position;
        }
        else if (tablet.CompareTag("ZamorakTablet"))
        {
            tablet.transform.position = zamorakStartPosition.position;
        }
        else if (tablet.CompareTag("GuthixTablet"))
        {
            tablet.transform.position = guthixStartPosition.position;
        }
        else if (tablet.CompareTag("AncientTablet"))
        {
            tablet.transform.position = ancientStartPosition.position;
        }
    }

    private void Update()
    {      
        if(saradominPlacedCorrect && zamorakPlacedCorrect && guthixPlacedCorrect && ancientPlacedCorrect)
        {
            
            soundManager.Play(SoundCat.PUZZLE_SOLVE);
            symbol3.SetActive(true);
            if (!completed) {
                GameManager.instance.NextState();
                completed = true;
            }   
        }
    }
}
