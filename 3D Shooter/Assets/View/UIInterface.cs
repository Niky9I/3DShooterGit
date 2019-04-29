using UnityEngine;

namespace Geekbrains
{
    public class UIInterface
    {
        private static PlayerUI _playerUI;

        public static PlayerUI PlayerUI
        {
            get
            {
                if (!_playerUI)
                    _playerUI = MonoBehaviour.FindObjectOfType<PlayerUI>();
                return _playerUI;
            }
        }



        private static WeaponUI _weaponUI;

        public static WeaponUI WeaponUI
        {
            get
            {
                if (!_weaponUI)
                    _weaponUI = MonoBehaviour.FindObjectOfType<WeaponUI>();
                return _weaponUI;
            }
        }

        //private SelectionObjMessageUi _selectionObjMessageUi;

        //public SelectionObjMessageUi SelectionObjMessageUi
        //{
        //    get
        //    {
        //        if (!_selectionObjMessageUi)
        //            _selectionObjMessageUi = MonoBehaviour.FindObjectOfType<SelectionObjMessageUi>();
        //        return _selectionObjMessageUi;
        //    }
        //}
    }
}