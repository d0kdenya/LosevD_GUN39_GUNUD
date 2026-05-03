using UnityEngine;

public class HitBox : MonoBehaviour
{
   public Health _health;

   public void OnRaycastHit(Weapon weapon, Vector3 direction)
   {
      _health.TakeDamage(weapon.Damage, direction);
   }
}
