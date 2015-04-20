using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int velocity;
	public int damage;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.up * velocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Enemy>())
		{
			collision.gameObject.GetComponent<Enemy>().DoDamage(damage);
			Destroy (gameObject);
		}
	}
}
