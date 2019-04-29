using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathTest : MonoBehaviour {

	[SerializeField] private Transform _target;
	private NavMeshPath _path;
	private GameObject _agent;
	private float _elapsed = 0.0f;



	// Use this for initialization
	private void Start () {
		_path = new NavMeshPath ();
		_agent = GameObject.FindGameObjectWithTag("Player");
		_elapsed = 0.0f;
	}
	
	// Update is called once per frame
	private void Update () {
		_elapsed += Time.deltaTime;
		if (_elapsed > 1.0f) {
			_elapsed -= 1.0f;
			NavMesh.CalculatePath (_agent.transform.position, _target.position, NavMesh.AllAreas, _path);
			// print (1);
		}
		for (int i = 0; i < _path.corners.Length - 1; i++)
			Debug.DrawLine (_path.corners [i], _path.corners [i + 1], Color.red);
		if (_path.corners.Length >= 2) {
		
			//_path.corners [1] идем на ближайшую точку к нам
		}
			
		
	}
}
