﻿using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		transform.Rotate(Random.insideUnitSphere * 360f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
