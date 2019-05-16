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
        private KeyCode _savePlayer = KeyCode.P;
        private KeyCode _loadPlayer = KeyCode.O;

        private Weapons _weapons;
        
	


		void Update ()
		{
            
            if (Input.GetKeyDown (KeyCode.F)) {
				_isActiveFlashlight = !_isActiveFlashlight;
				if (_isActiveFlashlight) {
					Main.Instance.GetFlashlightController.On ();
                    Debug.Log("включил фонарь");
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

                Debug.Log("Выбрал Шотган");
                SelectWeapon(0);
              
                //_indexWeapons = 0;
                               
                //_isSelectWeapons = true;
			}
			if (Input.GetKeyDown (KeyCode.Alpha0)) 
			{
                Main.Instance.GetWeaponController.Off();

                //_isSelectWeapons = false;
                
			}
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Выбрал Автомат");
                SelectWeapon(1);
               // _indexWeapons = 1;
                
                //_isSelectWeapons = true;
            }

            if (Input.GetKeyDown(_savePlayer))
            {
                Debug.Log("сохраняю");
                Main.Instance.SaveController.Save();
            }
            if (Input.GetKeyDown(_loadPlayer))
            {
                Debug.Log("загружаю");
                Main.Instance.SaveController.Load();
            }


   //         if (!_isSelectWeapons) {
			//	Main.Instance.GetWeaponController.Off ();
			//	return;
			//}
            
            
			if (Main.Instance.GetObjectManager.GetWeaponsList [_indexWeapons]) {
				// Передаем в контроллер стрельбы чем и из чего стрелять
				
				Main.Instance.GetWeaponController.On (Main.Instance.GetObjectManager.GetWeaponsList [_indexWeapons]);

			}

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                MouseScroll(MouseScrollWheel.Up);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                MouseScroll(MouseScrollWheel.Down);
            }


            //_isSelectWeapons = true; 

        }

		public int GetIndexWeapon //Возвращаем индекс выбранного оружия
		{ 
			get { return _indexWeapons; }

		}
        private void SelectWeapon(int value)
        {
            var tempWeapon = Main.Instance.GetObjectManager.SelectWeapon(value);
            SelectWeapon(tempWeapon);
        }

        private void MouseScroll(MouseScrollWheel value)
        {
            var tempWeapon = Main.Instance.GetObjectManager.SelectWeapon(value);
            SelectWeapon(tempWeapon);
        }
        private void SelectWeapon(Weapons weapon)
        {
            Main.Instance.GetWeaponController.Off();
            if (weapon != null)
            {
                Main.Instance.GetWeaponController.On(weapon);
                Debug.Log("Передал оружие");
            }
        }

    }
}