using System.Collections;
using UnityEngine;

namespace Geekbrains
{
	public sealed class Gun : Weapons
	{
		public override void Fire()
		{
            //Debug.Log("Пытаюсь стрелять");

            if (_fire) //Если можно стрелять
			{
                //Debug.Log("Моежно стрелять");
                if (Clip.CountAmmunition>0) 
				{
                    if (Ammunition)
                    {
                        //Создаем снаряд

                        var tempbullet = Instantiate(Ammunition, _gun.position, _gun.rotation);
                        // Всегда проверяйте существование объекта, прежде чем к нему обратиться!
                       
                        tempbullet.AddForce(_gun.forward * _force);     // Добавляем ускорение к пуле
                        _fire = false; // Сообщаем, что произошел выстрел
                        //tempbullet.Name = "Bullet"; // Задаем имя пуле
                       
                        Clip.CountAmmunition--;
                        
                        _recharge.Start(_rechargeTime); // Запускаем таймер

                        
                    }
				}
			}
				
		}
	}
}