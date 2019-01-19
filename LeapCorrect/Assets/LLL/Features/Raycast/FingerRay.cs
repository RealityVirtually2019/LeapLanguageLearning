using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerRay : MonoBehaviour {

	// Use this for initialization

	public GameObject IndexTip;
	public Vector3 FingertipPosition;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
 	FingertipPosition= IndexTip.transform.position;
	Vector3 fwd = transform.TransformDirection(Vector3.forward);
	RaycastHit hit;		

            if (Physics.Raycast(FingertipPosition, fwd, out hit))
            {

			Debug.DrawLine(FingertipPosition, hit.point);
				
				print (hit.point);

			    if (hit.rigidbody != null)
                {
					Debug.DrawLine(FingertipPosition, FingertipPosition + new Vector3 (10,10,10));
                }
            }
	}
}