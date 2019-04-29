using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Controller
{

	public class BotController : MonoBehaviour
	{
		private List<Bot> _botList = new List<Bot> ();
		private void Start()
		{
			
			Init ();
		}

		#region Property
		public List<Bot> GetBotList
		{
			get { return _botList; }
			private set { _botList = value; }
		}
		#endregion

		#region Public Function
		public void Init() //Вынесем инициализацию в отдельную функцию, чтобы можно было переинициализировать данные в другом месте
		{
			Transform tempTarget = GameObject.FindGameObjectWithTag ("Player").transform;

			Bot[] tempBots = Bot.FindObjectsOfType<Bot> () as Bot[];
		
			foreach (var tempBot in tempBots) 
			{
				AddBotToList (tempBot);
			}

			int i = -1;
			foreach (var tempBot in GetBotList) 
			{
				tempBot.agent.avoidancePriority = ++i;
				tempBot.Target = tempTarget;
			}
		}
		public void AddBotToList(Bot bot)
		{
			if (!GetBotList.Contains (bot)) 
			{
				GetBotList.Add (bot);
			}
		}
		public void RemoveBotToList(Bot bot)
		{
			if (GetBotList.Contains (bot)) 
			{
				GetBotList.Remove (bot);
			}
		}
		#endregion
	}
}