using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Interface;

namespace Geekbrains
{
    public class MagazineAK : BaseObjectScene
    {
        private int _maxAmmunition=30;
        public delegate void AddNewClip();
        public static event AddNewClip AddNewClipEvent;
        
         private void OnTriggerEnter(Collider collision)
        {
           
            if (collision.tag == "Player")

            {
                print("ПОДОБРАЛИ ОБОИМУ");
                AddNewClipEvent();
                Destroy(InstanceObject);
               
            }
        }

    }
}

