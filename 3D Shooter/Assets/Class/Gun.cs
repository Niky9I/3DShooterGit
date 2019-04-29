using System.Collections;
using UnityEngine;

namespace Geekbrains
{
	public class Gun : Weapons
	{
		public override void Fire(Ammunition ammunition)
		{
			

			if (_fire) //Если можно стрелять
			{
				
				if (ammunition) 
				{
					//Создаем снаряд

					Bullet tempbullet =Instantiate (ammunition, _gun.position, _gun.rotation) as Bullet;
					// Всегда проверяйте существование объекта, прежде чем к нему обратиться!
					if (tempbullet) 
					{

						tempbullet.GetRigidbody.AddForce(_gun.forward*_force); 	// Добавляем ускорение к пуле
						tempbullet.Name="Bullet"; // Задаем имя пуле
                        Clip.CountAmmunition--;
						_fire=false; // Сообщаем, что произошел выстрел
						_recharge.Start(_rechargeTime); // Запускаем таймер

					}
				}
			}
				
		}
	}
}