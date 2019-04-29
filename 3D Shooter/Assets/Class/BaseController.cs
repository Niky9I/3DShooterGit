using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Controller
{

	public abstract class BaseController : MonoBehaviour
	{
		public bool Enabled { get; protected set;}
		public virtual void On ()
		{
			Enabled = true;
		}
		public virtual void Off ()
		{
			Enabled = false;
		}

	}
}