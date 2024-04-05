using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningObject : MonoBehaviour
{
    public WeightScale weightScale;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        weightScale = GameObject.Find("Left Side").GetComponent<WeightScale>();
        panel.SetActive(false);
    }

    void objectSwitch(){
        GameObject.Find("The Cube").GetComponent<Renderer>().material.color = new Color(0, 250, 0);
        panel.SetActive(true);
		GameManager.instance.NextState();
    }
    // Update is called once per frame
    void Update()
    {
        if (weightScale.registeredRigidbodies == 3){
            objectSwitch();
        }
    }
}
