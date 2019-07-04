using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Controller
{
	// Класс оружия, из которого выходят снаряды
	public class WeaponController : BaseController
	{
		private Weapons _weapons;
		private Ammunition _ammunition;
		private int _mouseButton = (int) Main.MouseButton.LeftButton;
		
        

		private int _index;

     
        public void Update ()
		{
			//print ("пробую стрелять");
			if (!Enabled)
				return;
			if (Input.GetMouseButton(_mouseButton)) // Если зажата левая кнопка мыши
			{

                _weapons.Fire ();
             
                UIInterface.WeaponUI.ShowData(_weapons.Clip.CountAmmunition, _weapons.CountClip);

            }

		}
		public virtual void On (BaseObjectScene weapons)
		{
			if (Enabled)
				return;
			base.On (weapons);
            _weapons = weapons as Weapons;
            
            _weapons.IsVisible = true;
            UIInterface.WeaponUI.SetActive(true);
            UIInterface.WeaponUI.ShowData(_weapons.Clip.CountAmmunition, _weapons.CountClip);
           
        }

		public override void Off ()
		{
			if (!Enabled)
				return;
			base.Off ();
           
            _weapons.IsVisible = false;
            _weapons = null;
            UIInterface.WeaponUI.SetActive(false);
        }

        public void ReloadClip()
        {
            if (_weapons == null) return;
            _weapons.ReloadClip();
            UIInterface.WeaponUI.ShowData(_weapons.Clip.CountAmmunition, _weapons.CountClip);
        }
    }
}
