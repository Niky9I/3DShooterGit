using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Geekbrains.Helper;


namespace Geekbrains
{

    public sealed class LightUse : BaseObjectScene
    {
        private Light _light;
        private Transform _goFollow;
        private Vector3 _vcrOffset;
        private float _speed = 3;
        private float _timeout = 30;
        [SerializeField] private float _timeoutForCharging = 100;  // максимальное время работы фанарика
        [SerializeField] private float _intensity = 1.5f;
        [SerializeField] private Slider slider;
        private float _takeAwayTheIntensity;


        // элемент UI

        /// <summary>
        ///  цвета индикатора фанарика
        /// </summary>
        private Color _maxColor = Color.green;
        private Color _halfColor = Color.yellow;
        private Color _minColor = Color.red;
        private float _midCharge = 50;
        private float _minCharge = 20;


        private Image _sliderColor;



        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _vcrOffset = transform.position - _goFollow.position;
            _sliderColor = slider.fillRect.GetComponentInChildren<Image>();
            _takeAwayTheIntensity = _intensity / (_timeoutForCharging * 100);
        }

        void Start()
        {
            _sliderColor.color = _maxColor;
            slider.maxValue = 100;
            slider.minValue = 0;
            slider.value = 100;
        }

        public void Switch(bool isActive)
        {

            _light.enabled = isActive;
            transform.position = _goFollow.position + _vcrOffset;
            transform.rotation = _goFollow.rotation;
        }

        public void Rotat()
        {

            transform.position = _goFollow.position + _vcrOffset;
            transform.rotation = Quaternion.Slerp(transform.rotation, _goFollow.rotation, _speed * Time.deltaTime);
        }

        public bool BatteryChargeDown()
        {
            if (slider.value > 0)
            {
                slider.value -= Time.deltaTime * 5;
                if (slider.value < _midCharge) { _sliderColor.color = _halfColor; }
                if (slider.value < _minCharge) { _sliderColor.color = _minColor; }
                if (slider.value < _minCharge)
                {
                    _light.enabled = Random.Range(0, 100) >= Random.Range(0, 10);
                }
                else
                {
                    _light.intensity -= _takeAwayTheIntensity;
                }
                return true;
            }

            return false;
        }
        public void BatteryChargeUp()
        {
            if (slider.value < _timeoutForCharging)
            {

                slider.value += Time.deltaTime;
                if (slider.value > _minCharge) { _sliderColor.color = _halfColor; }
                if (slider.value > _midCharge) { _sliderColor.color = _maxColor; }


            }


        }
    }
}




 