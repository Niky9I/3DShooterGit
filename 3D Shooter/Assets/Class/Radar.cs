using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Radar : MonoBehaviour {


	public Transform PlayerPos { get; private set; } // Позиция главного героя
	private readonly float mapScale = 2;
	public static List<RadarObject> RadarObjects = new List<RadarObject> ();




	// Use this for initialization
	void Start () {
        PlayerPos = GameObject.FindGameObjectWithTag ("Player").transform;
        
	}

	public static void RegisterRadarObject (GameObject o, Image i)
	{
		Image image = Instantiate (i);
		RadarObjects.Add (new RadarObject { Owner = o, Icon = i });
	}

	public static void RemoveRadarObject(GameObject o)
	{
		List<RadarObject> newList = new List<RadarObject> ();
		foreach (RadarObject t in RadarObjects) 
		{
			if (t.Owner == o) 
			{
				Destroy (t.Icon);
				continue;
			}
			newList.Add (t);
		}
		RadarObjects.RemoveRange (0, RadarObjects.Count);
		RadarObjects.AddRange (newList);
	}

	private void DrawRadarDots() // Синхронизирует значки на миникарте с реальными объектами
	{
		foreach (RadarObject radObject in RadarObjects) 
		{
			Vector3 radarPos = (radObject.Owner.transform.position - PlayerPos.position);
			float distToObject = Vector3.Distance (PlayerPos.position, radObject.Owner.transform.position) * mapScale;
			float deltay = Mathf.Atan2 (radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - PlayerPos.eulerAngles.y;
			radarPos.x = distToObject * Mathf.Cos (deltay * Mathf.Deg2Rad) * -1;
			radarPos.z = distToObject * Mathf.Sin (deltay * Mathf.Deg2Rad);

			radObject.Icon.transform.SetParent (transform);
			radObject.Icon.transform.position = new Vector3 (radarPos.x, radarPos.z, 0) + transform.position;
		}
	}


	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 3 == 0) 
		{
			DrawRadarDots ();
		}
		
	}

	public class RadarObject
	{
		public Image Icon;
		public GameObject Owner;
	}
}