using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Interface;


namespace Geekbrains
{
    public class PlusMinusMassLength : BaseObjectScene, ISetDamage
    {
        public Transform Rope;
        public Rigidbody Mass;
        private float _ropeLength;
        private float _massMass;
        //GameObject gameObject;

        
        void Start()
        {
            // Rope =GameObject.FindGameObjectWithTag("Rope");
            //Transform RopeTransform = Rope.GetComponent<Transform>();
            _ropeLength = Rope.localScale.y;
            //GameObject Mass = GameObject.FindGameObjectWithTag("Mass");
            // MassRb = Mass.GetComponent<Rigidbody>();
            _massMass = Mass.mass;

            //_ropeLength = Rope.localScale.y;
            //_massMass = Mass.mass;
            print(this.gameObject.name);

        }
       

        


        public void SetDamage(InfoCollision info)
        {
            if (this.gameObject.name == "PlusMass")
            {
                print(Mass.mass);
                Mass.mass += 1;
            }
            else if (this.gameObject.name == "MinusMass")
            {
                print(Mass.mass);
                if (Mass.mass > 0)
                    Mass.mass -= 1;
            }
            else if (this.gameObject.name == "PlusLength")
            {
                print(Rope.localScale.y);
                Rope.localScale = new Vector3(Rope.localScale.x, Rope.localScale.y + 1, Rope.localScale.z);
            }
            else if (this.gameObject.name == "MinusLength")
            {
                print(Rope.localScale.y);
                if (Rope.localScale.y >= 1)
                   Rope.localScale = new Vector3(Rope.localScale.x, Rope.localScale.y-1, Rope.localScale.z);
            }
        }
    }
}
