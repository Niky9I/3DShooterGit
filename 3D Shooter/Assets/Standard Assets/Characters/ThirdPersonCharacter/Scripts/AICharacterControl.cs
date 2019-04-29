using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))] // Атрибут, обязующий добавить компонент, который указан в скобках вместе с данным компонентом (подробнее об атрибутах - в 5 уроке)
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
		public UnityEngine.AI.NavMeshAgent agent { get; private set; } // Ссылка на компонент, отвечающий за навигацию
		public ThirdPersonCharacter character { get; private set; } // Ссылка на компонент, отвечающий за перемещение персонажа
        public Transform target;                                    // target to aim for


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
