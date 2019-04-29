using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Helper
{
	// класс для хранения ссылок на объекты
	public class ObjectManager : MonoBehaviour
	{
		[SerializeField] private Ammunition[] _ammunitionList = new Ammunition[5];
		[SerializeField] private Weapons[] _weaponsList = new Weapons[5];
        

		#region Property
		public Weapons[] GetWeaponsList
		{
			get { return _weaponsList; }
		}

		public Ammunition[] GetAmmunitionList
		{
			get { return _ammunitionList; }
		}
       
		#endregion
	}
}
