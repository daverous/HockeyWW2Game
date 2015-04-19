using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class EquipableController : MonoBehaviour {

	public Equipable[] equipables;
	Equipable equipped;
	Equipable equippedObject;

	// Use this for initialization
	void Start () {
		equipped = equipables[0];
		equippedObject = new Equipable();
		equippedObject = Instantiate(equipped, transform.position, Quaternion.Euler(0, 0, 270)) as Equipable;
		equippedObject.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		// If an equip button is pressed, set equipped to the appropriate equipable
		for (int i=0;i<4;i++)
		{
			if (CrossPlatformInputManager.GetButtonDown("Equip" + i))
			{
				if (equipables[i] != null)
				{
					Debug.Log(equippedObject.name);
					Destroy (equippedObject.gameObject);
			  		equipped = equipables[i];
					equippedObject = new Equipable();
					equippedObject = Instantiate(equipped, transform.position, Quaternion.Euler(0, 0, 270)) as Equipable;
					equippedObject.transform.parent = transform;
				}
				else
					Debug.Log("Slot " + i + " is empty!");
			}
		}
	}
}
