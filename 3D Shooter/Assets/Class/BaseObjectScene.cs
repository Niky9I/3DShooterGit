using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Geekbrains
{
	// Базовый класс всех объектов на сцене
	public abstract class BaseObjectScene : MonoBehaviour
    {
		protected int _layer;
		protected Color _color;
		protected Material _material;
		protected Transform _myTransform;
		protected Vector3 _position;
		protected Quaternion _rotation;
		protected Vector3 _scale;
		protected GameObject _instanceObject;
		protected Rigidbody _rigidbody;
		protected string _name;
		protected bool _isVisible;

		#region UnityFunction
		protected virtual void Awake()
		{
			_instanceObject = gameObject;
			_name = _instanceObject.name;
			if (GetComponent<Renderer> ()) 
			{
				_material = GetComponent<Renderer> ().material;
			}
			_rigidbody = _instanceObject.GetComponent<Rigidbody> ();
			_myTransform = _instanceObject.transform;
		}
        #endregion

      

        #region Property
        // Имя объекта
        public string Name
		{
			get {return _name; }
			set
			{
				_name = value;
				_instanceObject.name = _name;

			}
		}

		// Слой объекта
		public int Layers
		{
			get {return _layer; }
			set
			{
				_layer = value;
				if (_instanceObject!=null)
					_instanceObject.layer = _layer;
				if (_instanceObject != null)
					AskLayer (GetTransform, value);
				
			}
		}
		// Цвет материала объекта
		public Color Color
		{
			get {return _color; }
			set
			{
				_color = value;
				if (_material!=null)
					_material.color = _color;
				AskColor (GetTransform, _color);

			}
		}

		// Матерал объекта
		public Material GetMaterial
		{
			get {return _material; }

		}
		// Позиция объекта
		public Vector3 Position
		{
			get 
			{
				if (_instanceObject != null)
					_position = GetTransform.position;
				return _position; 
			}
			set
			{
				_position = value;
				if (_instanceObject != null)
					GetTransform.position = _position;
			}
		}

		// Размер объекта
		public Vector3 Scale
		{
			get 
			{
				if (_instanceObject != null)
					_scale = GetTransform.localScale;
				return _scale; 
			}
			set
			{
				_scale = value;
				if (_instanceObject != null)
					GetTransform.localScale = _scale;
			}
		}

		// Поворот объекта
		public Quaternion Rotation
		{
			get 
			{
				if (_instanceObject != null)
					_rotation = GetTransform.rotation;
				return _rotation; 
			}
			set
			{
				_rotation = value;
				if (_instanceObject != null)
					GetTransform.rotation = _rotation;
			}
		}

        // Получить физику объекта
        

        public Rigidbody GetRigidbody
		{
			get { return _rigidbody; }

		}

		// Ссылка на GameObject
		public GameObject InstanceObject
		{
			get {return _instanceObject;}
		}

		// Скрывает/показывает объект
		public bool IsVisible
		{
			get { return _isVisible; }
			set
			{ 
				_isVisible = value;
                var tempRenderer = GetComponent<MeshRenderer>();
                if (tempRenderer)
                    tempRenderer.enabled = _isVisible;
                if (transform.childCount <= 0) return;
                foreach (Transform d in transform)
                {
                    tempRenderer = d.gameObject.GetComponent<MeshRenderer>();
                    if (tempRenderer)
                        tempRenderer.enabled = _isVisible;
                }
   
			}

		}

		// Получить Transform объекта
		public Transform GetTransform
		{
			get {return _myTransform;}
		}
		#endregion

		#region PrivateFunction
		// Выставляет слой себе и всем вложенным объектам
		private void AskLayer(Transform obj, int lvl)
		{
			obj.gameObject.layer = lvl; //выставляем объекту слой
			if (obj.childCount > 0) 
			{
				foreach (Transform d in obj) //проходит по всем вложенным объектам
					AskLayer(d,lvl); //рекурсивный метод
			}
		}

		// Выставляет цвет себе и всем вложенным объектам
		private void AskColor(Transform obj, Color color) 
		{
			obj.gameObject.GetComponent<Renderer>().material.color = color; //выставляем объекту слой
			if (obj.childCount > 0) 
			{
				foreach (Transform d in obj) //проходит по всем вложенным объектам
					AskColor(d,color); //рекурсивный метод
				}
		}
		#endregion
	}
}