using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
	// класс для хранения ссылок на объекты
	public class ObjectManager : MonoBehaviour
	{
		[SerializeField] public Ammunition[] _ammunitionList = new Ammunition[5];
		[SerializeField] public Weapons[] _weaponsList = new Weapons[5];
        public Weapons[] Weapons { get; private set; }
        private int _selectIndexWeapon = 0;
        public LightUse FlashLight { get; private set; }

        public void Start()
        {
            Weapons = Main.Instance.Player.GetComponentsInChildren<Weapons>();

            foreach (var weapon in Weapons)
            {
                weapon.IsVisible = false;
            }

            FlashLight = MonoBehaviour.FindObjectOfType<LightUse>();
            FlashLight.Switch(false);

        }

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


        /// <summary>
		/// Выбор оружия цифрами 
		/// </summary>
		/// <param name="weaponNumber">Индекс оружия</param>
		public Weapons SelectWeapon(int weaponNumber)
        {
            if (weaponNumber < 0 || weaponNumber >= Weapons.Length) return null;

            var tempWeapon = Weapons[weaponNumber];
            return tempWeapon;
        }

        /// <summary>
        /// Прокрутки оружия колесом мыши
        /// </summary>
        /// <param name="scrollWheel">Инкремент или декремент индекса</param>
        public Weapons SelectWeapon(MouseScrollWheel scrollWheel)
        {
            if (scrollWheel == MouseScrollWheel.Up)
            {
                if (_selectIndexWeapon < Weapons.Length - 1)
                {
                    _selectIndexWeapon++;
                }
                else
                {
                    _selectIndexWeapon = -1;
                }
                return SelectWeapon(_selectIndexWeapon);
            }

            if (_selectIndexWeapon <= 0)
            {
                _selectIndexWeapon = Weapons.Length;
            }
            else
            {
                _selectIndexWeapon--;
            }
            return SelectWeapon(_selectIndexWeapon);
        }
    }
}
