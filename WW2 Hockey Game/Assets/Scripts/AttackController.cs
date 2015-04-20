using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public enum AttackType
{
	mellee,
	ranged
}
public class AttackController : MonoBehaviour
{



	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Melee")) {
			//TODO perform animation
		}
	}

	void OnCollisionEnter (Collision other)
	{

	}
}
