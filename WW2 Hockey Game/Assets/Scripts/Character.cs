using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{


	#region fields
	public int maxHealth = 100;
	public int meleeDamage = 10;
	private int curHealth;
	private bool isInvincible;
	#endregion

	// Use this for initialization
	void Start ()
	{
		curHealth = maxHealth;
	}


	
	// Update is called once per frame
	void Update ()
	{
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

	void OnCollisonEnter (Collision other)
	{
		Equipable equipObj = other.gameObject.GetComponent<Equipable> ();

		// check if its an equipable obj
		if (equipObj != null && equipObj.isPickupable ()) {
			GetComponent<EquipableController> ().Equip (other.gameObject);

		}
	}
}
