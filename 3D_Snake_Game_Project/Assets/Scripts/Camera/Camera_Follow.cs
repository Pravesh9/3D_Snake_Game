using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {
	public Transform Target;
	public float smoothness;

	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - Target.position;

	}
	
	// Update is called once per frame
	void LateUpdate () 
	{

			if (transform.position != Target.position + offset) 
			{
				Vector3 temp = Vector3.Lerp (transform.position, Target.position + offset, smoothness * Time.deltaTime);

			temp.z = Mathf.Clamp(temp.z,offset.z,-offset.z);
			
				transform.position =temp;
			}	



		 
	}
}
