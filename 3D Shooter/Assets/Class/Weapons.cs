using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Helper;

namespace Geekbrains
{
	//Базовый класс для всех типов оружий

	public abstract class Weapons : BaseObjectScene 
	{
        private int _maxAmmunition = 30;
        private int _countClip = 5;
        public Ammunition Ammunition;
        public Clip Clip;

        //protected AmmunitionType[] ammunitionType = new AmmunitionType[] { AmmunitionType.Bullet };


		#region Serialize Varible
		//Позиция из которой будут вылетать снаряды
		[SerializeField] protected Transform _gun;
		//Сила выстрела
		[SerializeField] protected float _force=100;
		//Время задержки меджу выстрелами
		[SerializeField] protected float _rechargeTime;
        private Queue<Clip> _clips = new Queue<Clip>();

        // Можно добавить поля, которые хранили бы количество обойм, текущее количество патронов и т.д. 
        #endregion

        #region Protected Varible 
        protected Timer _recharge = new Timer (); 
		protected bool _fire = true; //Флаг, разрешающий выстрел

        #endregion

        private void Start()
        {
            for (var i = 0; i <= _countClip; i++)
            {
                AddClip(new Clip { CountAmmunition = _maxAmmunition });
            }

            ReloadClip();
        }


        #region Abstract Function
        //Функция для вызова выстрела, обязательна во всех дочерних классах
        public abstract void Fire();
		#endregion
	
		protected virtual void Update()
		// Тут можно дописать условие: если не выбрано оружие или выбрано не
		// огнестрельное оружие, то не производить подсчеты
		{
			
			_recharge.Update();

            // Производим подсчеты времени
            if (_recharge.IsEvent())
            { // Если закончили отсчет, разрешаем стрелять
                _fire = true;
               // Debug.Log("Можно стрелять");
            }
        }
        protected void AddClip(Clip clip)
        {
            _clips.Enqueue(clip);
        }

        public void ReloadClip()
        {
            if (CountClip <= 0) return;
            Clip = _clips.Dequeue();
        }

        public int CountClip => _clips.Count;
    }
}
