using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Controller
{

	public sealed class FlashlightController : BaseController
	{

		private LightUse _lightUse;

		// ссылка на источник света
		private void Start ()
		{
			_lightUse = FindObjectOfType<LightUse>();
		
			_lightUse.Switch(false); //при старте сцены выключаем фонарик
		}

		private void Update ()
		{
            if (!Enabled)
                _lightUse.BatteryChargeUp(); // ессли контроллер неактивен, востанавливаем заряд
            else
            {
                _lightUse.Rotat();
                if (_lightUse.BatteryChargeDown()) { }

                else
                {
                    Off();
                }
            }
          
		}

	

		public override void On ()
		{
			if (Enabled)
				return; // если контроллер включен, повторно не включаем
			base.On ();
			_lightUse.Switch (true);
		}

		public override void Off ()
		{
			if (!Enabled)
				return; // если контроллер выключен, повторно не выключаем
			base.Off ();
			_lightUse.Switch (false);
		}
	}

}
