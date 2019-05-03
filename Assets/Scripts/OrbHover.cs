using UnityEngine;
using System.Collections;

public class OrbHover : MonoBehaviour {
	public Material lightUpMaterial;
	public GameObject gameLogic;
	private Material defaultMaterial;
	public GameObject Station_Content;

	void Start () {
		defaultMaterial = this.GetComponent<MeshRenderer> ().material; 
		this.GetComponentInChildren<ParticleSystem>().enableEmission = false; 
		
		Station_Content.SetActive (false);

		gameLogic = GameObject.Find ("MuseumLogic");
	}
	
	void Update () {

		ToggleLights();
	
	}

	public void ToggleStation() {
		if(Station_Content.activeInHierarchy == false)
		{
			Station_Content.SetActive(true);			
		}
		
		else
		{
			Station_Content.SetActive(false);
		}

	}

	public void ToggleLights() 
	{
		if(Station_Content.activeInHierarchy == true)
		{
			this.GetComponent<MeshRenderer>().material = lightUpMaterial;
			this.GetComponentInChildren<ParticleSystem>().enableEmission = true;
		}
		else
		{
			this.GetComponent<MeshRenderer>().material = defaultMaterial;
			this.GetComponentInChildren<ParticleSystem>().enableEmission = false;
		}
	}

	public void gazeLightUp() {
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; 
		this.GetComponentInChildren<ParticleSystem>().enableEmission = true; 

	}

	public void gazeLightOff() {
		this.GetComponent<MeshRenderer>().material = defaultMaterial;
		this.GetComponentInChildren<ParticleSystem>().enableEmission = false;
	}


	
}
