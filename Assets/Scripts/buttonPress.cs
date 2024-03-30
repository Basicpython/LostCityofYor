using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class buttonPress : MonoBehaviour
{
	public GameObject button;
	public UnityEvent pressed;
	public UnityEvent released;
	public float originPX;
	public float originPY;
	public float originPZ;
	public float newPX;
	public float newPY;
	public float newPZ;
	GameObject presser;
	bool isPressed;
    
    void Start()
    {
        isPressed = false;
    }
	
	private void onTriggerEnter(Collider other){
		isPressed = true;
		if(isPressed){
			button.transform.localPosition = new Vector3(newPX,newPY,newPZ);
			print("contact");
			presser = other.gameObject;
			pressed.Invoke();
		}
	}
	
	private void OnTriggerExit(Collider other){
		
		if(other.gameObject == presser){
			button.transform.localPosition = new Vector3(originPX,originPY,originPZ);
			released.Invoke();
			isPressed = false;
		}
	}

}
