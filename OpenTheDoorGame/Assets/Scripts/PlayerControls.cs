using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    private RaycastHit hit;
    private Ray cameraRay;
    private GameObject collidingObject;
    private bool holding;


	void Start () {
        holding = false;
        collidingObject = null;
        cameraRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
	}
	

	void Update () {
        if (holding)
        {
            //runs while the player is holding an object.
            collidingObject.transform.position = Camera.main.transform.forward + Camera.main.transform.position;
            collidingObject.transform.rotation = Camera.main.transform.rotation;
            if (Input.GetMouseButtonDown(1))
            {
                //releases the object if 
                holding = false;
            }
        }
        cameraRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(cameraRay, out hit, 2f))
        {//Checking if the camera is facing a collider
            if (holding == false && Input.GetMouseButtonDown(0))
            {//Checks if mouse is being clicked, the player isn't already holding anything
                collidingObject = hit.collider.gameObject;
                if (collidingObject.tag == "key")
                {
                    //if the object has the 'key' tag, the player will hold it.
                    holding = true;
                }
            }
        }
        
	}

}
