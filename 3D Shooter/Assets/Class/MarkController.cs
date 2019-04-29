using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Controller
{
	public class MarkController : BaseController
	{

		private MarkUse _markUse;

		private void Start ()
		{
			_markUse = FindObjectOfType<MarkUse>();

		}

		void Update()
		{
			_markUse.Mark ();
			//_markUse.OnGUI ();

		}

	}
}
