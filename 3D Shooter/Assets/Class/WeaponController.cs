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
		public Weapons SelecteWeapons // Оружие, которое сейчас выбрано
		{get {return _weapons;}}

		private int _index;

        public void Awake()
        {
            Weapons[] _allWeapons = FindObjectsOfType<Weapons>();
            foreach (var i in _allWeapons)
            {
                i.IsVisible = false;
            }
            //UIInterface.WeaponUI.ShowData(SelecteWeapons.Clip.CountAmmunition, SelecteWeapons.CountClip);
        }
        public void Update ()
		{
			//print ("пробую стрелять");
			if (!Enabled)
				return;
			if (Input.GetMouseButton(_mouseButton)) // Если зажата левая кнопка мыши
			{
				
				_ammunition=Main.Instance.GetObjectManager.GetAmmunitionList [Main.Instance.GetInputController.GetIndexWeapon];

				SelecteWeapons.Fire (_ammunition);
                UIInterface.WeaponUI.ShowData(SelecteWeapons.Clip.CountAmmunition, SelecteWeapons.CountClip);

            }

		}
		public virtual void On (Weapons weapons, Ammunition ammunition)
		{
			if (Enabled)
				return;
			base.On ();
			_weapons = weapons;
			_weapons.IsVisible = true;
		}

		public override void Off ()
		{
			if (!Enabled)
				return;
			base.Off ();
		
			_weapons.IsVisible = false;
		}

        public void ReloadClip()
        {
            if (SelecteWeapons == null) return;
            SelecteWeapons.ReloadClip();
            UIInterface.WeaponUI.ShowData(SelecteWeapons.Clip.CountAmmunition, SelecteWeapons.CountClip);
        }
    }
}
