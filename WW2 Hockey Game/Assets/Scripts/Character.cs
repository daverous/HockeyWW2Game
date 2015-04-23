using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Character : MonoBehaviour
{


	#region fields
	public int maxHealth = 100;
	public int meleeDamage = 10;
	private int curHealth;
	private GameObject inRange;
	private bool isInvincible;
	private bool perform; // true if Action is being pressed by player
	#endregion

	// Use this for initialization
	void Start ()
	{
		perform = false;
		inRange = null;
		curHealth = maxHealth;
	}


	
	// Update is called once per frame
	void Update ()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Action") && inRange != null) {
			Debug.Log ("here");
			perform = true;
			GetComponentInChildren<EquipableController> ().Pickup (inRange);
		}
		if (CrossPlatformInputManager.GetButtonUp ("Action")) {
			perform = false;
		}
		//TODO use curEquiped to update currently equiped weapon
	}

	public void increaseHealth (int incr)
	{
		if (incr + curHealth > 100) {
			curHealth = 100;
		} else {
			curHealth += incr;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		//		Debug.Log (other.gameObject.name);
		//Debug.Log (other.gameObject.name);
		Equipable equipObj = other.gameObject.GetComponent<Equipable> ();
		
		// check if its an equipable obj
		if (equipObj != null && equipObj.isPickupable ()) {
			Debug.Log (other.gameObject.name);
			inRange = other.gameObject;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == inRange) {
			inRange = null;
		}
	}

	/*
	void OnCollisionEnter (Collision other)
	{
//		Debug.Log (other.gameObject.name);
		Equipable equipObj = other.gameObject.GetComponent<Equipable> ();

		// check if its an equipable obj
		if (equipObj != null && equipObj.isPickupable ()) {
			inRange = other.gameObject;
		}
	}

	void OnCollisionExit (Collision other)
	{
		if (other.gameObject == inRange) {
			inRange = null;
		}
	}
	*/
}
