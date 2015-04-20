using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public enum AttackType
{
	melee,
	ranged,
	empty
}
public class AttackController : MonoBehaviour
{
	private AttackType curAttack;
	private int meleeDamage;

	// Use this for initialization
	void Start ()
	{
		meleeDamage = this.GetComponent<Character> ().meleeDamage;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Melee")) {
			curAttack = AttackType.melee;
			//TODO perform animation
		} else if (CrossPlatformInputManager.GetButtonUp ("Melee")) {
			curAttack = AttackType.empty;
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (curAttack == AttackType.melee) {
			string tag = other.gameObject.tag; 
			if (tag == "Enemy") {
				other.gameObject.GetComponent<Enemy> ().DoDamage (meleeDamage);
			}
		}
	}

	void OnCollisionExit (Collision exit)
	{
	
	}

	public AttackType getCurAttack ()
	{
		return curAttack;
	}

	public void setCurAttack (AttackType at)
	{
		curAttack = at;
	}
}
