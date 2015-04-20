using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : Equipable
{
	
	#region vars
	public Bullet bullet;
	Bullet bulletObject;
	#endregion
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Fire1") && isEquiped ()) {
//			bu	lletObject = new Bullet ();
			bulletObject = Instantiate (bullet, transform.position, transform.rotation) as Bullet;
			Destroy (bulletObject.gameObject, 5f);
		}
	}
}
