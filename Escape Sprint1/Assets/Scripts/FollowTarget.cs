using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public Transform target;
	private Vector3 offset;

    private float minFov = 60f;
    private float maxFov = 100f;
    private float sensitivity = 50f;

	void Awake(){

		offset = new Vector3(0,2f,0) * 5.5f;
	}
    
	void Update (){
        
        float fov = GetComponent<Camera>().fieldOfView;

        fov += Input.mouseScrollDelta.y * sensitivity * Time.deltaTime;
        fov = Mathf.Clamp(fov, minFov, maxFov);

        GetComponent<Camera>().fieldOfView = fov;

		transform.position = target.position + offset;
        
	}
    public void MovimientoCamara(Transform pos)
    {
        float fov = GetComponent<Camera>().fieldOfView;

        fov += Input.mouseScrollDelta.y * sensitivity * Time.deltaTime;
        fov = Mathf.Clamp(fov, minFov, maxFov);

        GetComponent<Camera>().fieldOfView = fov;

        transform.position = target.position + offset;
        //transform.position = Instantiate(target.position) + offset;
    }

}
