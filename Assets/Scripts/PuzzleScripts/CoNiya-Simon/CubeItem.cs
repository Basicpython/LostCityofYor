using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CubeItem : MonoBehaviour
{
    public GameObject redbutton;
    public GameObject orangebutton;
    public GameObject yellowbutton;
    public GameObject greenbutton;
    public GameObject bluebutton;
    public GameObject purplebutton;
    public GameObject ActivatedButton;

    private float[] simonSequence;
    private float[] currentSequence;
    private bool solved = false;

    // Start is called before the first frame update
    void Start()
    {
        simonSequence = new float[6];
        currentSequence = new float[6];
        simonSequence[0] = 1f;
        simonSequence[1] = 5f;
        simonSequence[2] = 3f;
        simonSequence[3] = 4f;
        simonSequence[4] = 2f;
        simonSequence[5] = 6f;
        currentSequence[0] = 6f;
        currentSequence[1] = 4f;
        currentSequence[2] = 3f;
        currentSequence[3] = 2f;
        currentSequence[4] = 1f;
        currentSequence[5] = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Renderer activated = ActivatedButton.GetComponent<Renderer>();

        // Get the material currently assigned to the cube
        Material readyMaterial = activated.material;

        Renderer button1 = redbutton.GetComponent<Renderer>();

        // Get the material currently assigned to the cube
        Material currentMaterial1 = button1.material;

        // check the first button is pressed
        if (currentMaterial1.name == readyMaterial.name)
        {
            currentSequence[0] = 1f;
        }

        Renderer button2 = bluebutton.GetComponent<Renderer>();
        // Get the material currently assigned to the cube
        Material currentMaterial2 = button2.material;

        // check the second button is pressed
        if (currentMaterial2.name == readyMaterial.name && currentSequence[0] == 1f)
        {
            currentSequence[1] = 5f;
            // reset the code otherwise
        }
        else if (currentMaterial2.name == readyMaterial.name && currentSequence[0] != 1f)
        {
            currentSequence[0] = 6f;
            currentSequence[1] = 4f;
            currentSequence[2] = 3f;
            currentSequence[3] = 2f;
            currentSequence[4] = 1f;
            currentSequence[5] = 5f;
        }

        Renderer button3 = yellowbutton.GetComponent<Renderer>();
        // Get the material currently assigned to the cube
        Material currentMaterial3 = button3.material;

        // check the second button is pressed
        if (currentMaterial3.name == readyMaterial.name && currentSequence[1] == 5f)
        {
            currentSequence[2] = 3f;
            // reset the code otherwise
        }
        else if (currentMaterial3.name == readyMaterial.name && currentSequence[1] != 5f)
        {
            currentSequence[0] = 6f;
            currentSequence[1] = 4f;
            currentSequence[2] = 3f;
            currentSequence[3] = 2f;
            currentSequence[4] = 1f;
            currentSequence[5] = 5f;
        }

        Renderer button4 = greenbutton.GetComponent<Renderer>();
        // Get the material currently assigned to the cube
        Material currentMaterial4 = button4.material;

        // check the second button is pressed
        if (currentMaterial4.name == readyMaterial.name && currentSequence[2] == 3f)
        {
            currentSequence[3] = 4f;
            // reset the code otherwise
        }
        else if (currentMaterial4.name == readyMaterial.name && currentSequence[2] != 3f)
        {
            currentSequence[0] = 6f;
            currentSequence[1] = 4f;
            currentSequence[2] = 3f;
            currentSequence[3] = 2f;
            currentSequence[4] = 1f;
            currentSequence[5] = 5f;
        }

        Renderer button5 = orangebutton.GetComponent<Renderer>();
        // Get the material currently assigned to the cube
        Material currentMaterial5 = button5.material;

        // check the second button is pressed
        if (currentMaterial5.name == readyMaterial.name && currentSequence[3] == 4f)
        {
            currentSequence[4] = 2f;
            // reset the code otherwise
        }
        else if (currentMaterial5.name == readyMaterial.name && currentSequence[3] != 4f)
        {
            currentSequence[0] = 6f;
            currentSequence[1] = 4f;
            currentSequence[2] = 3f;
            currentSequence[3] = 2f;
            currentSequence[4] = 1f;
            currentSequence[5] = 5f;
        }

        Renderer button6 = purplebutton.GetComponent<Renderer>();
        // Get the material currently assigned to the cube
        Material currentMaterial6 = button6.material;

        // check the second button is pressed
        if (currentMaterial6.name == readyMaterial.name && currentSequence[4] == 2f)
        {
            currentSequence[5] = 6f;
            // reset the code otherwise
        }
        else if (currentMaterial6.name == readyMaterial.name && currentSequence[4] != 2f)
        {
            currentSequence[0] = 6f;
            currentSequence[1] = 4f;
            currentSequence[2] = 3f;
            currentSequence[3] = 2f;
            currentSequence[4] = 1f;
            currentSequence[5] = 5f;
        }

        if (simonSequence[5] == currentSequence[5] && solved == false)
        {
            print("solved");
            solved = true;
        }
    }
}