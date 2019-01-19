using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycast : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		RaycastHit hit;

		if (Physics.Raycast(this.transform.position,Vector3.forward,out hit))

		{  
			print (hit.point);
			Debug.DrawLine(this.transform.position, hit.point);
		}

	
    }
	

}
