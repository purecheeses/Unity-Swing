using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedBar : MonoBehaviour {
    public GameObject button1;
    public GameObject button2;
    float beginLength;
	// Use this for initialization
	void Start () {
        beginLength = (button1.transform.position - button2.transform.position).magnitude;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = (button1.transform.position + button2.transform.position) / 2;
        transform.position = new Vector3(pos.x, pos.y, -1);
        float length = (button1.transform.position - button2.transform.position).magnitude;
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x,length/beginLength, scale.z);
        float angle = Vector2.Angle(button1.transform.position - button2.transform.position, Vector2.right);
        if (button1.transform.position.y < button2.transform.position.y)
            angle *= -1;
        transform.rotation = Quaternion.AngleAxis(90+angle, Vector3.forward);
	}


}
