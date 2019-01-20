using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


    [RequireComponent(typeof(ControllerConnectionHandler))]


public class LabelCast : MonoBehaviour {



	

	public Transform Label;
	public GameObject DebugObject;
	public Vector3 Hitpoint;


	  public GameObject ForwardCursor;
	// Use this for initialization
	void Start () 
	{


	}
	
	// Update is called once per frame
	void Update () {

	



	}

 	void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

		RaycastHit hit;

        if (Physics.Raycast(transform.TransformPoint(ForwardCursor.transform.position), fwd, out hit))
		{
		print("I found something");

		Hitpoint = hit.point;

		DebugObject.transform.position =hit.point;
		//Instantiate(Label, Hitpoint, Quaternion.identity);
		}

    }

	    

}
