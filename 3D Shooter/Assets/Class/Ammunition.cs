using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{

	 public abstract class Ammunition : BaseObjectScene
	{
        [SerializeField] private float _timeToDestruct = 10; //время жизни пули
        [SerializeField] private float _damage = 20; // урон пули
        [SerializeField] private float _mass = 0.01f; // масса пули
        protected float _curDamage;
        protected float _lossOfDamageAtTime = 0.2f;

        //public AmmunitionType Type = AmmunitionType.Bullet;
        protected override void Awake()
        {
            base.Awake();
            _curDamage = _damage;
        }

        private void Start()
        {
            Destroy(gameObject, _timeToDestruct);
            InvokeRepeating(nameof(LossOfDamage), 0, 1);
        }
        public void AddForce(Vector3 dir)
        {
            if (!GetRigidbody) return;
            GetRigidbody.AddForce(dir);
           
        }

        protected void LossOfDamage()
        {
            _curDamage -= _lossOfDamageAtTime;
        }
    }
}