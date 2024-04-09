using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
	public GameObject Door;
	public GameObject SimonButton;
	public GameObject ScalesButton;
	public GameObject ActivatedButton;
	private float[] passcode;
	private float[] currentcode;
	private bool opened = false;
	private float openingTime = 0;
	private Vector3 startingPos = new Vector3(9.668083f,11.43208f,-1.252816f);
	private Vector3 endingPos = new Vector3(9.668083f,7.35f,-1.252816f);
	

    // Start is called before the first frame update
    void Start()
    {
		passcode = new float[2];
		currentcode = new float[2];
		passcode[0] = 1f;
		passcode[1] = 2f;
		currentcode[0] = 2f;
		currentcode[1] = 1f;
    }

    // Update is called once per frame
    void Update()
    {
		Renderer activated = ActivatedButton.GetComponent<Renderer>();
		
        // Get the material currently assigned to the cube
        Material readyMaterial = activated.material;
		
		Renderer button1 = SimonButton.GetComponent<Renderer>();
		
        // Get the material currently assigned to the cube
        Material currentMaterial1 = button1.material;
		
		if (currentMaterial1.name == readyMaterial.name){
			currentcode[0] = currentcode[1];
		}
		
		Renderer button2 = ScalesButton.GetComponent<Renderer>();
        // Get the material currently assigned to the cube
        Material currentMaterial2 = button2.material;
		
		if (currentMaterial2.name == readyMaterial.name && currentcode[0] == 1f){
			currentcode[1] = 2f;
		}
		
		if (passcode[0] == currentcode[0] && passcode[1] == currentcode[1] && opened == false){
			opened = true;
			
		}
		
		if(openingTime < 1000 && opened){
			transform.Translate(Vector3.up * Time.deltaTime);
			openingTime = openingTime + 1;
		}
			
		
	
    } 
	
}
