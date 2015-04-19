using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class EquipableController : MonoBehaviour {

	public Equipable[] equipables;
	Equipable equipped;

	// Use this for initialization
	void Start () {
		equipped = equipables[0];
	}
	
	// Update is called once per frame
	void Update () {
		// If an equip button is pressed, set equipped to the appropriate equipable
		for (int i=0;i<4;i++)
			if (CrossPlatformInputManager.GetButtonDown("Equip" + i))
			    equipped = equipables[i];
	}
}
