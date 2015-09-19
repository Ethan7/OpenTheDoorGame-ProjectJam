using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

    private RaycastHit hit;
    public GameObject other;
	
	// Update is called once per frame
	void Update () {
	     if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out hit, 2f))
         {
             if(Input.GetMouseButtonDown(0) && hit.collider.gameObject == this.gameObject)
             {
                 other.transform.position = this.transform.position;
                 Destroy(this.gameObject);
             }
         }
	}
}
