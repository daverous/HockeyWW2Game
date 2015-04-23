using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public int health;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void Die ()
	{
		GetComponentInChildren<Weapon>().setPickupable(true);
		transform.DetachChildren();
		Destroy (gameObject);
	}

	public void DoDamage (int damage)
	{
		health -= damage;
		if (health <= 0)
			Die ();
	}
}
