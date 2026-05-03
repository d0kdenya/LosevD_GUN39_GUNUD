using UnityEngine;

public class AIIdleState : AIState
{
   public void Enter(AIAgent agent)
   {
   }

   public void Exit(AIAgent agent)
   {
   }

   public AIStateID GetID()
   {
      return AIStateID.Idle;
   }

   public void Update(AIAgent agent)
   {
      Vector3 playerDirection = agent.PlayerTransform.position - agent.transform.position;

      if (playerDirection.magnitude > agent.Config.MaxSibhtDistance)
      {
         return;
      }

      Vector3 agentDirection = agent.transform.forward;

      playerDirection.Normalize();

      float dotProduct = Vector3.Dot(playerDirection, agentDirection);

      if (dotProduct > 0)
      {
         agent.StateMachine.ChangeState(AIStateID.ChasePlayer);
      }
   }
}
