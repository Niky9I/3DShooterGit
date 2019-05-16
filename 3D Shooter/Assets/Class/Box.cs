using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Interface;


namespace Geekbrains
{

	public class Box : BaseObjectScene, ISetDamage
	{
		[SerializeField] private float _hp = 100;
		private bool _isDead = false;
		private float _step = 2f;

	
		void Update ()
		{
			if (_isDead) //запускаем анимацию смерти
			{
				Color color = GetMaterial.color;
				if (color.a > 0) // понижаем альфа-канал (плавное затухание)
				{
					color.a -= _step / 100;
					Color = color;
				}
				if (color.a < 1) 
				{
					Destroy (InstanceObject.GetComponent<Collider> ());
					Destroy (InstanceObject, 5f);
				}
			}
		}
		public void SetDamage (InfoCollision info)
		{
			if (_hp>0) //если  жизний больше 0, получаем урон
				_hp-=info.Damage;
			if (_hp <= 0) 
			{
				_hp = 0;
				Color = Color.red;
				_isDead = true;
			}
		}
	}
}
