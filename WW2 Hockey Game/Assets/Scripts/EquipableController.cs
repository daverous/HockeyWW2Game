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
		for (int i=0; i<4; i++) {
			if (equipables [i] != null) {
				equipables [i] = Instantiate (equipables [i], transform.position, Quaternion.Euler (0, 0, 270)) as GameObject;
				equipables [i].SetActive (false);
				equipables [i].transform.parent = transform;
			}
		}
		equipables [equipped].SetActive (true);
		equipables [equipped].GetComponent<Equipable> ().setEquiped (true);
//		equipables [equipped].transform.position = transform.position;
		Debug.Log (equipables [equipped].transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If an equip button is pressed, set equipped to the appropriate equipable
		for (int i=0; i<4; i++) {
			if (CrossPlatformInputManager.GetButtonDown ("Equip" + i)) {
				Debug.Log ("bitchin equip brah");
				if (equipables [i] != null) {
					equipables [equipped].SetActive (false);
					equipped = i;
					equipables [equipped].SetActive (true);
					equipables [equipped].GetComponent<Equipable> ().setEquiped (true);
//					equipables [equipped].transform.position = transform.position;
				} else
					Debug.Log ("Slot " + i + " is empty!");
			}
		}
	}

	public void Equip (GameObject obj)
	{
		Debug.Log ("in equip");
		for (int i=0; i<4; i++) {
			if (equipables [i] == null) {
				equipables [equipped].SetActive (false);
				equipables [equipped].GetComponent<Equipable> ().setEquiped (false);
				obj.GetComponent<Equipable> ().setPickupable (false);
				obj.GetComponent<Equipable> ().setEquiped (true);
				equipables [i] = obj.gameObject;
				equipped = i;
				equipables [i].transform.rotation = Quaternion.Euler (0, 0, 270);
				equipables [i].transform.parent = transform;
				return;
			}
		}
		Vector3 tempPos = obj.transform.position;
		GameObject temp = equipables [equipped];
		temp.SetActive (false);
		temp.GetComponent<Equipable> ().setEquiped (false);
		temp.GetComponent<Equipable> ().setPickupable (true);
		equipables [equipped] = obj;
		equipables [equipped].transform.parent = transform;
		temp.transform.parent = null;
		temp.transform.position = tempPos;
	}
}
