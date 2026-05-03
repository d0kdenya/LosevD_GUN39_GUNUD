using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField]
   private AIAgent _agent;

   [SerializeField]
   private float _maxHealth;

   private float _currentHealth;

   private Ragdoll _ragdoll;

   private UIHealthBar _healthBar;

   private void Start()
   {
      _ragdoll = GetComponent<Ragdoll>();
      _currentHealth = _maxHealth;

      _healthBar = GetComponent<UIHealthBar>();

      var rigidBodies = GetComponentsInChildren<Rigidbody>();

      foreach (var rigidBody in rigidBodies)
      {
         HitBox hitBox = rigidBody.gameObject.AddComponent<HitBox>();
         hitBox._health = this;
      }
   }

   public void TakeDamage(float amount, Vector3 direction)
   {
      _currentHealth -= amount;

      _healthBar.SetHealthBarPercentage(_currentHealth /  _maxHealth);

      if (_currentHealth <= 0)
      {
         Die();
      }
   }

   private void Die()
   {
      AIDeathState deathState = _agent.StateMachine.GetState(AIStateID.Death) as AIDeathState;
      _agent.StateMachine.ChangeState(AIStateID.Death);
   }
}
