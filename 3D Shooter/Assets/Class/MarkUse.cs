using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{

	public sealed class MarkUse : BaseObjectScene
	{
		
		[SerializeField] private Transform _camera;
		private RaycastHit hit;
		private bool _showName;


		public void Mark ()
		{


			Vector3 Direction = _camera.TransformDirection (Vector3.forward);
			if (Physics.Raycast (_camera.position, Direction, out hit, 5)) //заставляет бить из нашей камеры луч на дистанцию равную 5
				{
                if (hit.collider != null)
                {
                    _showName = true;

                }
                else
                {
                    _showName = false;
                }
			}
		}

        public void OnGUI()
        {
            if ((_showName) && (hit.collider))
            {
                GUI.Label(new Rect((Screen.width) / 2, (Screen.height) / 2, 125, 25), " " + hit.collider.name);
            }
		}
	} 
}