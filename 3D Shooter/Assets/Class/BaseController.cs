using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Controller
{

	public abstract class BaseController : MonoBehaviour
	{
		public bool Enabled { get; protected set;}
        public virtual void On()
        {
            Enabled = true;
        }

        //public bool IsActive { get; private set; }
        public virtual void On(BaseObjectScene obj)
        {
            Enabled = true;
        }
        public virtual void Off ()
		{
			Enabled = false;
		}

	}
}