using UnityEngine;
using System.Collections;

public class RaycastMovement : MonoBehaviour {
	public GameObject raycastHolder;
	public GameObject player;
	public GameObject raycastIndicator;

	public float height = 2;
	public bool teleport = true;

	public float maxMoveDistance = 10;
	
	private bool moving = false;

	RaycastHit hit;
	float theDistance;

	void Start () {
	
	}
	
	void Update () {
		
		Vector3 forwardDir = raycastHolder.transform.TransformDirection (Vector3.forward) * 100;
		//Debug.DrawRay (raycastHolder.transform.position, forwardDir, Color.green);

		if (Physics.Raycast (raycastHolder.transform.position, (forwardDir), out hit)) {

			if (hit.collider.gameObject.tag == "movementCapable") {
				ManageIndicator ();
				if (hit.distance <= maxMoveDistance) { 

					
					if (raycastIndicator.activeInHierarchy == false) {
						raycastIndicator.SetActive (true);
					}
				

					if (Input.GetMouseButtonDown (0)) {
						if (teleport) {
							teleportMove (hit.point);
						} else {
							DashMove (hit.point);
						}
					}
				} else {
					if (raycastIndicator.activeInHierarchy == true) {
						raycastIndicator.SetActive (false);
					}
				}
			}
				
		}
	
	}
	public void ManageIndicator() {
		if (!teleport) {
			if (moving != true) {
				raycastIndicator.transform.position = hit.point;
			}
			if(Vector3.Distance(raycastIndicator.transform.position, player.transform.position) <= 2.5) {
				moving = false;
			}

		} else {
			raycastIndicator.transform.position = hit.point;
		}
	}
	public void DashMove(Vector3 location) {
		moving = true;

		iTween.MoveTo (player, 
			iTween.Hash (
				"position", new Vector3 (location.x, location.y + height, location.z), 
				"time", .2F, 
				"easetype", "linear"
			)
		);
	}
	public void teleportMove(Vector3 location) {
		player.transform.position = new Vector3 (location.x, location.y + height, location.z);
	}
}
