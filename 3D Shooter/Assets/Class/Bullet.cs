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
        public GameObject projectorWall;
        public GameObject projectorEnemy;
        public int maxProjectors = 50;
        private GameObject[] projectorsArray;
        private int tmpCount;
        private GameObject projector;

        private float _currentDamage; // текущий урон, который может нанести пуля
		protected override void Awake()
		{
			base.Awake ();
			Destroy (InstanceObject, _timeToDestruct); //если пуля никого не встретит, то самоуничтожится
			_currentDamage = _damage;
			GetRigidbody.mass = _mass;
            projectorsArray = new GameObject[maxProjectors];
        }

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.tag == "Bullet") // если столкнулась с другой пулей, то ничего не делаем
				return;
            //print (collision.collider.name);
            ContactPoint contact = collision.contacts[0];
            Vector3 _pos = contact.point; //позиция коллайдера со стеной
           


			SetDamage (collision.gameObject.GetComponent<ISetDamage> ());
			// вызываем урон
			// частицы от взрыва и т. п.

			

            Quaternion projectorRotation = Quaternion.FromToRotation(-Vector3.forward, contact.normal);

            switch (collision.collider.gameObject.layer)
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
            print(projector);
            if (projector)
            {

                GameObject obj = Instantiate(projector, contact.point + contact.normal * 0.25f, projectorRotation) as GameObject;
                print("ДЫРКА");
                Destroy(projectorsArray[tmpCount]);
                projectorsArray[tmpCount] = obj;

                obj.transform.parent = collision.collider.transform;

                Quaternion randomRotZ = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, Random.Range(0, 360));
                obj.transform.rotation = randomRotZ;

                if (tmpCount == maxProjectors - 1) tmpCount = 0; else tmpCount++;
            }

            Destroy(InstanceObject); //удаляем пулю
        }
		private void SetDamage (ISetDamage obj)
		{
			if (obj != null)
				obj.ApplyDamage (_currentDamage);
			
		}

	}
}