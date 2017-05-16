using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SivaForm{
	ball,           //球状
	open,           //从球状展开
	close,           //从展开状收回
	layDown,        //展开状   
};


public class SivaTransform : MonoBehaviour {
	public SivaForm mForm;
	// Use this for initialization
	void Start () {
		mForm = SivaForm.ball;			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void transform(){
		if (mForm == SivaForm.ball) {
			ballToOpen ();
		} else if (mForm == SivaForm.open) {
			//变形中
			return ;
		}
		else if (mForm == SivaForm.close) {
			//变形中
			return;
		}
		else if (mForm == SivaForm.layDown) {
			laydownToClose ();
		}
	}

	void ballToOpen(){
		
	}

	void laydownToClose(){
		
	}
}
