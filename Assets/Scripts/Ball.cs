using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure this has a rigidbody to do GetComponent on
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {
	public Rigidbody rigidBody { get; private set; }
	public Vector3 push;
	public GameObject duplicate;
	
	private float delay=0.1f;

	private float countdown=0.1f;
	private int flag = 1;
	

	void Awake() {
		rigidBody = GetComponent<Rigidbody>();
	}

	/// <summary>
	/// Add a instantaneous force to the ball
	/// </summary>
	/// <param name="force"></param>
	public void AddForce(Vector3 force) {
		rigidBody.AddForce(force, ForceMode.VelocityChange);
	}
	void OnCollisionEnter (Collision collisionInfo)
	{

		if (collisionInfo.collider.tag == "ankit")
			
			{


			flag = 0;

			}
	}
	void Update()
    {
		if(countdown>=0 && flag==0)
		countdown -= Time.deltaTime;
		if (countdown <= 0)
		{
			GameObject BallIns = Instantiate(duplicate, transform.position, transform.rotation);
			BallIns.GetComponent<Rigidbody>().AddForce(push, ForceMode.VelocityChange);
			countdown = delay;
			flag = 1;
		}

	}
}
