﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MakeRadarObject : MonoBehaviour {
	public Image Image;

	// Use this for initialization
	private void Start () {
		Radar.RegisterRadarObject (gameObject, Image);		
	}
	
	// Update is called once per frame
	private void OnDestroy () {
		Radar.RemoveRadarObject (gameObject);
	}
}
