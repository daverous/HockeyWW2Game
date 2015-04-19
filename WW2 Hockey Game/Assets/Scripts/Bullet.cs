using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.up * 20;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
