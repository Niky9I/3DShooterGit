using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Interface;

namespace Geekbrains
{
    public class MedKit : BaseObjectScene
    {
        [SerializeField] private float _maxKit = 50;
        [SerializeField] private float _minKit = 10;

        private void OnTriggerEnter(Collider collision)
        {
            print("МЕНЯ ПОДОБРАЛИ");
            if ((collision.tag == "Bot") || (collision.tag == "Player"))
            {
                SetHealth(collision.gameObject.GetComponentInParent<ISetHealth>());
                Destroy(InstanceObject);
            }
        }

        private void SetHealth(ISetHealth obj)
        {
            if (obj != null)
            {
                obj.ApplyMedKit(Random.Range(_minKit, _maxKit));
            }
        }
    }
}
