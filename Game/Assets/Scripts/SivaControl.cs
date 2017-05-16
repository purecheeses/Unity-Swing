using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SivaControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		TransformButton ();
	}

	void TransformButton(){
		if(Input.GetKeyDown(KeyCode.A)){
			GetComponent<SivaTransform> ().transform ();
		}
		if(Input.GetKeyDown(KeyCode.B)){
			
		}
	}
}
