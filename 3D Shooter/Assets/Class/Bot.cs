﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geekbrains.Interface;
using UnityEngine.AI;

namespace Geekbrains
{
	[RequireComponent (typeof(NavMeshAgent))]
	public class Bot : BaseObjectScene, ISetDamage, ISetHealth
	{
		[SerializeField] private float _hp = 100;


		#region Readonly
		// Время ожидания на контрольной точке
		private readonly float _timeWait=3;
		private readonly float _activeDistance=50;
		private readonly float _activeAngle=50;
		private readonly float _stoppingDistance = 10;
		#endregion

		//Список контрольных точек
		private List<Vector3> _wayPoints=new List<Vector3>();
		//Текущая контрольная точка
		private int _wayCount;
		//Счетчик времени
		private float _curTimeout;
		//Если цель найдена
		private bool _isTarget;
		private bool _isDeath;
		//Цель противника
		public NavMeshAgent agent { get; private set;} 		
		private Weapons _weapons;		

		private Transform _target;
		public Transform Target
		{
			get { return _target;}
			set { _target = value;}
		}


		protected override void Awake ()
		{
			base.Awake ();
			_isDeath = false;
			agent = GetComponent<NavMeshAgent> ();
			_weapons = GetTransform.Find ("Gun").GetComponent<Weapons> ();
            var bodyBot = GetComponentInChildren<BodyBot>();
            if (bodyBot != null) bodyBot.OnApplyDamageChange += SetDamage;

            var headBot = GetComponentInChildren<HeadBot>();
            if (headBot != null) headBot.OnApplyDamageChange += SetDamage;
        }

		void Start()
		{
			// Находим контрольные точки
			// Контрольные точки будем искать по тегу, поэтому обязательно добавляем тег WayPoints
			GameObject[] tempWayPoints=GameObject.FindGameObjectsWithTag("WayPoints");
			foreach (var tempWayPoint in tempWayPoints) 
			{
				_wayPoints.Add (tempWayPoint.transform.position);
				//print (_wayPoints);
			}
			//находим игрока
			//Target=Main.Instance.GetBotController.Init();


		
		}


		// Update is called once per frame
		void Update ()
		{
            float _curStoppingDistance;
			//print (_target.name);
			// Если умерли или нет цели, то не производим расчеты
			if (_isDeath || !Target) 
			{
				print ("я сдох");
				return;
			}

			float dis = Vector3.Distance (Position, Target.position);
			if (dis < _activeDistance) 
			{
				if (Vector3.Angle (GetTransform.forward, Target.position - Position) <= _activeAngle) 
				{
					if (!CheckBlocked()) // Если цель не закрыта припятствием
					{
						_isTarget = true; // Цель замечена
					}
				}
			}
				


			if (_wayPoints.Count >= 2 && !_isTarget) {
                _curStoppingDistance = 0;
                //print(_wayCount);
                agent.stoppingDistance = _curStoppingDistance;
				agent.SetDestination (_wayPoints [_wayCount]);
				ChangePoint();
				//Если некуда идти
				if (!agent.hasPath) {
                    // Отсчитываем время
                    Debug.Log("некуда идти");
					_curTimeout += Time.deltaTime;
					if (_curTimeout > _timeWait) {
						_curTimeout = 0;
						GenerationWayPoints ();
					}
				}
			} 
			else if (_wayPoints.Count == 0 || _isTarget) 
			{
                _curStoppingDistance = _stoppingDistance;

                agent.stoppingDistance = _curStoppingDistance;
				agent.SetDestination (Target.position);
                //Debug.Log("Бот стреляет");
				_weapons.Fire ();

			}
		}

		private void ChangePoint()
		{
			if (Vector3.Distance (_wayPoints [_wayCount], transform.position) <= _stoppingDistance) 
			{
                if (_wayCount >= _wayPoints.Count-1d)
                    _wayCount=0;
				_wayCount++;
                
			}
		}
	 
		private bool CheckBlocked()
		{
			RaycastHit hit;
			Debug.DrawLine (Position, Target.position, Color.red);
			if (Physics.Linecast (Position, Target.position, out hit)) 
			{
				if (hit.transform == Target)
					return false;
			}
			return true;
		}

		private void GenerationWayPoints()
		{
			if (_wayCount < _wayPoints.Count - 1)
				_wayCount++;
			else
				_wayCount = 0;
		}
		
		public void SetDamage(InfoCollision info)
		{
			if (_hp > 0) 
			{
				_hp -= info.Damage;
			}
			if (_hp <= 0) 
			{
				_hp = 0;
				_isDeath = true;
				agent.enabled = false;

				// Проходим по всем вложенным объектам
				foreach (Transform child in GetComponentInChildren<Transform>()) 
				{
					// Отделяем их от родителя
					child.parent=null;

					// Удалим этот объект через 10 секунд
					Destroy(child.gameObject,10);
					if (!child.gameObject.GetComponent<Rigidbody> ()) 
					{
						child.gameObject.AddComponent<Rigidbody> ();
					}
				}


				//EnableRigidBody (); // Включаем физику
				Destroy(InstanceObject,10);
				Main.Instance.GetBotController.RemoveBotToList (this);
			}
		}

        public void ApplyMedKit(float kit)
        {
            if (_hp < 100)
            {
                _hp += kit;
                if (_hp > 100)
                {
                    _hp = 100;
                }
            }
        }

	}
}
