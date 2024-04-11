using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPuzzle : MonoBehaviour
{
	public GameObject Door;
	public GameObject SimonButton;
	public GameObject ScalesButton;
	public GameObject SpiritButton;
	public GameObject TabletButton;
	public GameObject ActivatedButton;
	public GameObject gameWinCanvas;

    private float[] passcode;
	private float[] currentcode;
	private bool opened = false;
	private float openTime = 0;
	private Vector3 startingPos = new Vector3(9.52f,11.21f,-9.36f);
	private Vector3 endingPos = new Vector3(9.52f,8.35f,-9.36f);
	

    // Start is called before the first frame update
    void Start()
    {
		passcode = new float[4];
		currentcode = new float[4];
		passcode[0] = 1f;
		passcode[1] = 2f;
		passcode[2] = 3f;
		passcode[3] = 4f;
		currentcode[0] = 2f;
		currentcode[1] = 1f;
		currentcode[2] = 4f;
		currentcode[3] = 3f;
        gameWinCanvas.SetActive(false);
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
		
		// check the first button is pressed
		if (currentMaterial1.name == readyMaterial.name){
			currentcode[0] = 1f;
		}
		
		Renderer button2 = ScalesButton.GetComponent<Renderer>();
        // Get the material currently assigned to the cube
        Material currentMaterial2 = button2.material;
		
		// check the second button is pressed
		if (currentMaterial2.name == readyMaterial.name && currentcode[0] == 1f){
			currentcode[1] = 2f;
		// reset the code otherwise
		} else if (currentMaterial2.name == readyMaterial.name && currentcode[0] != 1f){
			currentcode[0] = 2f;
			currentcode[1] = 1f;
			currentcode[2] = 4f;
			currentcode[3] = 3f;
		}
		
		Renderer button3 = TabletButton.GetComponent<Renderer>();
        // Get the material currently assigned to the cube
        Material currentMaterial3 = button3.material;
		
		// check the second button is pressed
		if (currentMaterial3.name == readyMaterial.name && currentcode[1] == 2f){
			currentcode[2] = 3f;
		// reset the code otherwise
		} else if (currentMaterial3.name == readyMaterial.name && currentcode[1] != 2f){
			currentcode[0] = 2f;
			currentcode[1] = 1f;
			currentcode[2] = 4f;
			currentcode[3] = 3f;
		}
		
		Renderer button4 = SpiritButton.GetComponent<Renderer>();
        // Get the material currently assigned to the cube
        Material currentMaterial4 = button4.material;
		
		// check the second button is pressed
		if (currentMaterial4.name == readyMaterial.name && currentcode[2] == 3f){
			currentcode[3] = 4f;
		// reset the code otherwise
		} else if (currentMaterial4.name == readyMaterial.name && currentcode[2] != 3f){
			currentcode[0] = 2f;
			currentcode[1] = 1f;
			currentcode[2] = 4f;
			currentcode[3] = 3f;
		}
		
		if (passcode[3] == currentcode[3] && opened == false){
			opened = true;
		}
		
		if(openTime < 1000 && opened){
			transform.Translate(Vector3.up * Time.deltaTime);
			openTime = openTime + 1;
			if (openTime == 1000) {
				gameWinCanvas.SetActive(true);
			}
		}
	
    } 
}
