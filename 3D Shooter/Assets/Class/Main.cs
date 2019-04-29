using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Controller;
using Geekbrains.Helper;


namespace Geekbrains
{

	public sealed class Main : MonoBehaviour
	{
		private GameObject _controllersGameObject;
		private InputController _inputController;
		private FlashlightController _flashlightController;
		private MarkController _markController;

		public static Main Instance { get; private set; }
		
		private WeaponController _weaponsController;
		private ObjectManager _objectManager;
		private BotController _botController;


		public enum MouseButton
		{
			LeftButton,
			RightButton,
			CenterButton
		}


        private void Awake()
        {
            _objectManager = GetComponent<ObjectManager>();
        }
        void Start ()
		{
			Instance = this;

			_controllersGameObject = new GameObject{ name = "Controllers" };
           
            _inputController = _controllersGameObject.AddComponent<InputController>();
        
            _flashlightController = _controllersGameObject.AddComponent<FlashlightController>();
      
            _markController = _controllersGameObject.AddComponent<MarkController>();
    
            _weaponsController = _controllersGameObject.AddComponent<WeaponController>();
   
            _botController = _controllersGameObject.AddComponent<BotController>();
     
            _objectManager = GetComponent<ObjectManager>();
      
        }

		#region Property
		// Получить контроллер фонарика
		public FlashlightController GetFlashlightController
		{
			get { return _flashlightController;}
		}

		// Получить контроллер ввода данных
		public InputController GetInputController
		{
			get { return _inputController;}
		}

		public WeaponController GetWeaponController
		{
			get { return _weaponsController;}
		}

		public ObjectManager GetObjectManager
		{
            get { return _objectManager;}
		}

		public BotController GetBotController
		{
			get { return _botController;}
		}
		public MarkController GetMarkController
		{
			get { return _markController;}
		}
     
        #endregion


    }
}
