using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public enum EquipableTypes
{
	Weapon,
	Health,
	Tool
}
public class EquipableController : MonoBehaviour
{

	public GameObject[] equipables;
	int equipped;

	// Use this for initialization
	void Start ()
	{
		equipped = 0;
		equipables [equipped].transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If an equip button is pressed, set equipped to the appropriate equipable
		for (int i=0; i<4; i++) {
			if (CrossPlatformInputManager.GetButtonDown ("Equip" + i)) {
				if (equipables [i] != null) {
					equipables [equipped].SetActive (false);
					equipped = i;
					equipables [equipped].SetActive (true);
//					equipables [equipped].transform = transform;
				} else
					Debug.Log ("Slot " + i + " is empty!");
			}
		}
	}

	public void Equip (GameObject obj)
	{
		for (int i=0; i<4; i++) {
			if (equipables [i] == null) {
				obj.GetComponent<Equipable> ().setPickupable (false);
				equipables [i] = obj.gameObject;
				equipped = i;
				return;
			}
		}
		Vector3 tempPos = obj.transform.position;
		GameObject temp = equipables [equipped];
		equipables [equipped] = obj;
		equipables [equipped].transform.parent = temp.transform;
		temp.transform.position = tempPos;
		temp.GetComponent<Equipable> ().setPickupable (true);
	}
}
