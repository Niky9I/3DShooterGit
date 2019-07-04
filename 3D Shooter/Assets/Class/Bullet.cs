using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Interface;

namespace Geekbrains
{

	public sealed class Bullet : Ammunition
	{
        public GameObject projectorWall;
        public GameObject projectorEnemy;
        public int maxProjectors = 50;
        private GameObject[] projectorsArray;
        private int tmpCount;
        private GameObject projector;
        private float _currentDamage; // текущий урон, который может нанести пуля

        void Start()
        {

            projectorsArray = new GameObject[maxProjectors];
        }

        private void OnCollisionEnter(Collision collision)
		{
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();
            if (tempObj != null)
                tempObj.SetDamage(new InfoCollision(_curDamage, collision.contacts[0], collision.transform, GetRigidbody.velocity));



            // вызываем урон
            // частицы от взрыва и т. п.
            Quaternion projectorRotation = Quaternion.FromToRotation(-Vector3.forward, collision.contacts[0].normal);

            switch (collision.transform.gameObject.layer)
            {
                case 8: // номер слоя с плоскими объектами
                    projector = projectorWall;
                    print("попал в стену");

                    break;
                case 9: // номер слоя с моделями персонажей или рельефных объектов
                    projector = projectorEnemy;
                    print("попал в человека");
                    break;
            }
            print(collision.collider.gameObject.name);
            if (projector)
            {

                var obj = Instantiate(projector, collision.contacts[0].point + collision.contacts[0].normal * 0.25f, projectorRotation) as GameObject;
                print("ДЫРКА");
                Destroy(projectorsArray[tmpCount]);
                projectorsArray[tmpCount] = obj;

                obj.transform.parent = collision.transform;

                Quaternion randomRotZ = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, Random.Range(0, 360));
                obj.transform.rotation = randomRotZ;

                if (tmpCount == maxProjectors - 1) tmpCount = 0; else tmpCount++;
            }




            Destroy(InstanceObject); //удаляем пулю
        }
		

	}
}