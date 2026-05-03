using UnityEngine;
using UnityEngine.AI;

public class AILocomotion : MonoBehaviour
{
   [SerializeField]
   private Transform _playerTransform;

   [SerializeField]
   private float _maxTime;

   [SerializeField]
   private float _maxDistance;

   private NavMeshAgent _agent;

   private float _timer;

   private Animator _animator;

   private void Start()
   {
      _agent = GetComponent<NavMeshAgent>();
      _animator = GetComponent<Animator>();
   }

   private void Update()
   {
      _timer = _maxTime;


      if (_timer <= 0)
      {
         float sqDistance = (_playerTransform.position - _agent.destination).sqrMagnitude;

         if (sqDistance > _maxDistance * _maxDistance)
         {
            _agent.destination = _playerTransform.position;
         }
         _timer = _maxDistance;
      }
      _animator.SetFloat("Speed", _agent.velocity.magnitude);
   }
}