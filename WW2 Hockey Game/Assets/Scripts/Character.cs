using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{


	#region fields
	public int maxHealth = 100; 
	private int curHealth;
	public Equipable[] equiped; 
	private int curEquiped; //default to 0
	private bool isInvincible;
	#endregion

	// Use this for initialization
	void Start ()
	{
		curHealth = maxHealth;
		curEquiped = 0;
	}


	
	// Update is called once per frame
	void Update ()
	{
		//TODO use curEquiped to update currently equiped weapon
	}

	public void equip (int pos)
	{
		if (pos < equiped.Length)
			curEquiped = pos - 1;
	}

	public void pickupEquipable (Equipable eq)
	{
		equiped [curEquiped] = eq;
	}

	public void increaseHealth (int incr)
	{
		if (incr + curHealth > 100) {
			curHealth = 100;
		} else {
			curHealth += incr;
		}
	}
}
