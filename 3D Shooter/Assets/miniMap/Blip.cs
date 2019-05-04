using UnityEngine;
using System.Collections;
namespace Geekbrains
{

    public class Blip : MonoBehaviour
    {

        //public Transform target;
        public bool inBounds;
        public float minScale = 1;

        private RectTransform rect;
        private Radar map;
        Transform _playerPos;
        Vector3 _tempPos, _tempRot;

        void Start()
        {
            map = GetComponentInParent<Radar>();
            rect = GetComponent<RectTransform>();
            _playerPos= GameObject.FindGameObjectWithTag("Player").transform;
        }

        void LateUpdate()
        {
            Vector3 pos = _playerPos.position;
            Quaternion rot = _playerPos.rotation; 
            Vector3 _tempRot= new Vector3(rot.x, rot.y, rot.z+90);

            //if (inBounds) pos = map.MoveInside(pos);
            //float scale = Mathf.Max(minScale, map.zoom);
            //rect.localScale = new Vector3(scale, scale, 1);
            
            rect.localEulerAngles = _tempRot;
            _tempPos.x = (-pos.x*2-60);
            _tempPos.y = (-pos.z*2+15);

            rect.localPosition = _tempPos;

            
                ;

        }
    }
}