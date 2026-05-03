using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
   public AIStateMachine StateMachine;

   public AIStateID InitialState;

   [SerializeField]
   private AIAgentConfig _config;

   private Ragdoll _ragdoll;

   private Transform _playerTransform;

   private NavMeshAgent _navMeshAgent;

   public Transform PlayerTransform => _playerTransform;

   public NavMeshAgent NavMeshAgent => _navMeshAgent;

   public AIAgentConfig Config => _config;

   public Ragdoll Ragdoll => _ragdoll;

   private void Start()
   {
      _ragdoll = GetComponent<Ragdoll>();
      _navMeshAgent = GetComponent<NavMeshAgent>();

      if (_playerTransform == null)
      {
         _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
      }
      
      StateMachine = new AIStateMachine(this);
      StateMachine.RegisterState(new AIChasePlayerState());

      StateMachine.RegisterState(new AIDeathState());
      StateMachine.RegisterState(new AIIdleState());

      StateMachine.ChangeState(InitialState);
   }

   private void Update()
   {
      StateMachine.Update();
   }
}
