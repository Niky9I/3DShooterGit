using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Helper;

namespace Geekbrains.Controller
{
	//Контроллер, который отвечает за «горячие» клавиши
	
	public sealed class InputController : BaseController
	{
		private bool _isActiveFlashlight = false;
		private bool _isSelectWeapons = false;
		private int _indexWeapons = 0;

		private Weapons _weapons;
        
	


		void Update ()
		{
			if (Input.GetKeyDown (KeyCode.F)) {
				_isActiveFlashlight = !_isActiveFlashlight;
				if (_isActiveFlashlight) {
					Main.Instance.GetFlashlightController.On ();
				} else {
					Main.Instance.GetFlashlightController.Off ();
				}
			}
            // Меняем оружие по нажатию клавиш

            //if (Input.GetAxis("MouseScrollWheel")>0)
            // MouseS

            if (Input.GetKeyDown(KeyCode.R))
            {
                Main.Instance.GetWeaponController.ReloadClip();
            }

            if (Input.GetKeyDown (KeyCode.Alpha1)) {

				_indexWeapons = 0;

               
                _isSelectWeapons = true;
			}
			if (Input.GetKeyDown (KeyCode.Alpha0)) 
			{
          
              
                _isSelectWeapons = false;
                
			}
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _indexWeapons = 1;
                
                _isSelectWeapons = true;
            }




            if (!_isSelectWeapons) {
				Main.Instance.GetWeaponController.Off ();
				return;
			}

            
			if ((Main.Instance.GetObjectManager.GetWeaponsList [_indexWeapons]) && (Main.Instance.GetObjectManager.GetAmmunitionList [_indexWeapons])) {
				// Передаем в контроллер стрельбы чем и из чего стрелять
				print (_indexWeapons);
				Main.Instance.GetWeaponController.On (Main.Instance.GetObjectManager.GetWeaponsList [_indexWeapons], Main.Instance.GetObjectManager.GetAmmunitionList [_indexWeapons]);

			}
			//_isSelectWeapons = true; 

		}

		public int GetIndexWeapon //Возвращаем индекс выбранного оружия
		{ 
			get { return _indexWeapons; }

		}
       

	}
}