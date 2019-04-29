using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Geekbrains
{
	public class MiniMapScript : MonoBehaviour
	{

		private Transform _player;


		// Use this for initialization
		private void Start ()
		{
			_player = GameObject.FindGameObjectWithTag ("Player").transform;
				
		}
	
		// Update is called once per frame
		private void LateUpdate ()
		{
			Vector3 newPosition = _player.position;
			newPosition.y = transform.position.y;
			transform.position = newPosition;

			transform.rotation = Quaternion.Euler (90,_player.eulerAngles.y,0);
		}
	}
}