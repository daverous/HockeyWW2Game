using UnityEngine;
using System.Collections;

public class Equipable : MonoBehaviour
{

	#region
	public bool canPick;
	private bool equiped; 
	#endregion
	// Use this for initialization
	void Start ()
	{
		if (transform.parent == null) {
			canPick = true;
		} else {
			canPick = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.parent.name == "Equipped")
		{
			transform.position = transform.parent.position;
			transform.eulerAngles = new Vector3 (0, 0, 270);
		}
	}

	public void setPickupable (bool val)
	{
		canPick = val;
	}
	public bool isPickupable ()
	{
		return canPick;
	}

	public bool isEquiped ()
	{
		return equiped;
	}

	public void setEquiped (bool val)
	{
		equiped = val;
	}
}
