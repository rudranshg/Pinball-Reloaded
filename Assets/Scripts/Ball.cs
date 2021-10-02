using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure this has a rigidbody to do GetComponent on
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {
	public Rigidbody rigidBody { get; private set; }
	public Vector3 push;
	public GameObject duplicate;
	
	private float delay= 1;

	private float countdown;
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
			if (flag == 1)
			{
				GameObject BallIns = Instantiate(duplicate, transform.position, transform.rotation);
				BallIns.GetComponent<Rigidbody>().AddForce(push, ForceMode.VelocityChange);
				flag = 0;
				BallIns.GetComponent<Ball>().flag = 0;
				countdown = delay;
				BallIns.GetComponent<Ball>().countdown = delay;
			}
		}
	}
	void Update()
    {
		if (flag == 0)
		{
			countdown -= Time.deltaTime;
		}
		if(countdown<0)
        {
			flag = 1;
			countdown = delay;
        }

	}
}
