using UnityEngine;
using UnityEngine.AI;

public class AIChasePlayerState : AIState
{
   public float _timer;

   public AIStateID GetID()
   {
      return AIStateID.ChasePlayer;
   }

   public void Enter(AIAgent agent)
   {
   }

   public void Exit(AIAgent agent)
   {
   }

   public void Update(AIAgent agent)
   {
      _timer -= Time.deltaTime;

      if (!agent.NavMeshAgent.hasPath)
      {
         agent.NavMeshAgent.destination = agent.PlayerTransform.position;
      }

      if (_timer < 0)
      {
         Vector3 direction = (agent.PlayerTransform.position - agent.NavMeshAgent.destination);
         direction.y = 0;

         if (direction.sqrMagnitude > agent.Config.MaxDistance * agent.Config.MaxDistance)
         {
            if (agent.NavMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
            {
               agent.NavMeshAgent.destination = agent.PlayerTransform.position;
            }
         }
         _timer = agent.Config.MaxDistance;
      }
   }
}
