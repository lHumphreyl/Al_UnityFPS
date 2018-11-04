using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace FPS
{
	public class TeammateModel : MonoBehaviour 
	{
		private NavMeshAgent _agent;
		private ThirdPersonCharacter _character;

		private Queue<Vector3> MoveList;
		[SerializeField]
		private int maxMoveCommands = 8;
		private bool isMoving = false;

		void Start()
		{
			_agent = GetComponent<NavMeshAgent>	();
			_character = GetComponent<ThirdPersonCharacter>	();

			_agent.updateRotation = false;
			_agent.updatePosition = true;

			MoveList = new Queue<Vector3> (maxMoveCommands);
		}

		void Update()
		{
			if (_agent.remainingDistance > _agent.stoppingDistance) 
			{
				_character.Move (_agent.desiredVelocity, false, false);
				isMoving = true;
			}
			else 
			{
				isMoving = false;
				_character.Move (Vector3.zero, false, false);
				if (!isMoving && MoveList.Count > 0) 
				{
					_agent.SetDestination (MoveList.Dequeue ());
					MoveList.TrimExcess ();
				}
			}
		}

		public void SetDestination(Vector3 pos)
		{
			NavMeshHit hit;

			if (NavMesh.SamplePosition (pos, out hit, 5f, -1)) 
			{
				MoveList.Enqueue (hit.position);
			}
		}
	}
}
