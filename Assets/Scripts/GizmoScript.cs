using UnityEngine;

public class GizmoScript : MonoBehaviour
{
   private EnemyScript _enemy;

   private void OnDrawGizmos()
   {
      if (_enemy == null)
      {
         _enemy = GetComponent<EnemyScript>();
      }

      Vector3 viewOrigin = _enemy.transform.position + _enemy.ViewCenter;

      Gizmos.color = Color.yellow;
      Gizmos.DrawWireSphere(viewOrigin, _enemy.ViewRadius);

      Vector3 viewAngleA = DirFromAngle(-_enemy.ViewAngle / 2, false);
      Vector3 viewAngleB = DirFromAngle(_enemy.ViewAngle / 2, false);

      Gizmos.color = Color.red;
      Gizmos.DrawLine(viewOrigin, viewOrigin + viewAngleA * _enemy.ViewRadius);
      Gizmos.DrawLine(viewOrigin, viewOrigin + viewAngleB * _enemy.ViewRadius);
   }

   private Vector3 DirFromAngle(float angleInDegrees, bool angleInGlobal)
   {
      if (!angleInGlobal)
      {
         angleInDegrees += transform.eulerAngles.y;
      }
      return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
   }
}
