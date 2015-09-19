using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    private RaycastHit hit;
    private Ray cameraRay;
    private GameObject collidingObject;
    private bool holding;
    private Ray objRay;
    public string holdingTag;//name of the tag that is the object that will be held.
    public string reactingTag;//name of the tag that will react to the held object.


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
            objRay = new Ray(collidingObject.transform.position, collidingObject.transform.forward);
            if (Input.GetMouseButtonDown(1))
            {
                //releases the object with right click 
                holding = false;
            }
            if (Physics.Raycast(objRay, out hit, 1f))
            {//Checking if the ray from the held object hits a collider
                if(hit.collider.gameObject.tag == reactingTag)
                {
                    Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                    rb.useGravity = true;
                }
            }
        }
        cameraRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(cameraRay, out hit, 2f))
        {//Checking if the camera is facing a collider
            if (holding == false && Input.GetMouseButtonDown(0))
            {//Checks if mouse is being clicked, the player isn't already holding anything
                collidingObject = hit.collider.gameObject;
                if (collidingObject.tag == holdingTag)
                {
                    //if the object has the 'key' tag, the player will hold it.
                    holding = true;
                }
                if(collidingObject.tag == "appearable")
                {
                    Object[] objects = FindObjectsOfType(collidingObject.GetType());
                    for(int i=0; i<objects.Length; i++)
                    {
                        GameObject temp = (GameObject)objects[i];
                        if(temp.tag == collidingObject.tag)
                        {
                            temp.transform.position = collidingObject.transform.position;
                        }
                    }
                    Destroy(collidingObject);
                }
            }
        }
        
	}

}
