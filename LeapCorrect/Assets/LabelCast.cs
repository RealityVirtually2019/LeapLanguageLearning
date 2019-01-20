using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelCast : MonoBehaviour {


	public Transform Label;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	



	}

 	void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

		RaycastHit hit;

        if (Physics.Raycast(this.transform.position, fwd, out hit))
		{
		print("I found something");
;		 Instantiate(Label, hit.point, Quaternion.identity);	
		}
         
    }


}
