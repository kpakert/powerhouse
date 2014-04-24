﻿using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

	private const float CD = 0.5f;
	private float timer;
	private bool time;
	private GameObject explosion;

	// Use this for initialization
	void Start()
	{
		time = false;
		explosion = Resources.Load<GameObject>("BoatExplosion");
	}
	
	// Update is called once per frame
	void Update()
	{
		if (!time) 
		{
			float dtime = Time.deltaTime;
			Vector3 forward = this.transform.forward;
			transform.position += forward * 6 * dtime;

		}

		if (this.transform.childCount < 2 && !time) 
		{
			Vector3 up = new Vector3(0f,1f,0f);
			var obj = GameObject.Instantiate(explosion, this.transform.position + up, Quaternion.identity);
			time = true;
			timer = 0;
		}

		if (time)
		{
			timer += Time.deltaTime;
			if (timer > CD)
			{

				GameObject.Destroy( this.gameObject );
			}
		}
	}


	private void OnCollisionEnter( Collision o )
	{
        GameController.Instance.onBoatCollision( this.gameObject );
	}
}
