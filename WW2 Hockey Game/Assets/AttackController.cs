using UnityEngine;
using System.Collections;

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
