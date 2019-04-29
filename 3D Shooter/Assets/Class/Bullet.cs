using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Interface;

namespace Geekbrains
{

	public class Bullet : Ammunition
	{

		[SerializeField] private float _timeToDestruct = 10; //время жизни пули
		[SerializeField] private float _damage = 20; // урон пули
		[SerializeField] private float _mass = 0.01f; // масса пули

		private float _currentDamage; // текущий урон, который может нанести пуля
		protected override void Awake()
		{
			base.Awake ();
			Destroy (InstanceObject, _timeToDestruct); //если ауля никого не встретит, то самоуничтожится
			_currentDamage = _damage;
			GetRigidbody.mass = _mass;
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.tag == "Bullet") // если столкнулась с другой пулей, то ничего не делаем
				return;
			print (collision.collider.name);
		

			SetDamage (collision.gameObject.GetComponent<ISetDamage> ());
			// вызываем урон
			// частицы от взрыва и т. п.

			Destroy (InstanceObject); //удаляем пулю
		}
		private void SetDamage (ISetDamage obj)
		{
			if (obj != null)
				obj.ApplyDamage (_currentDamage);
			
		}

	}
}