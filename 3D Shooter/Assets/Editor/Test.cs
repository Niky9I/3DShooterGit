using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	[SerializeField] private GameObject _prefab;

	public void InstantiateObj(Vector3 pos)
	{
		Instantiate (_prefab, pos, Quaternion.identity);
	}
}
