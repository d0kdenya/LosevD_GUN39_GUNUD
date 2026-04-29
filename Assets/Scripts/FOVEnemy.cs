using UnityEngine;

public class FOVEnemy : MonoBehaviour
{
   public float ViewRadius = 10f;   // Дальность обзора

   [Range(0, 360)]
   public float ViewAngle = 90f;    // Угол обзора

   public LayerMask TargetMask;     // Маска игрока

   public LayerMask ObstacleMask;   // Маска препятствия

   private Transform PlayerTransform;

   private void Start()
   {
      PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
   }

   private void Update()
   {
      FindVisibleTargets();
   }

   private void FindVisibleTargets()
   {
      float distanceToTarget = Vector3.Distance(transform.position, PlayerTransform.position);

      if (distanceToTarget <= ViewRadius)
      {
         Vector3 dirToTarget = (PlayerTransform.position - transform.position).normalized;

         if (Vector3.Angle(transform.forward, dirToTarget) < ViewAngle / 2)
         {
            if (Physics.Raycast(transform.position, dirToTarget, distanceToTarget, TargetMask))
            {
               Debug.Log("Игрок замечен!");
            }
         }
      }
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.yellow;
      Gizmos.DrawWireSphere(transform.position, ViewRadius);

      Vector3 viewAngleA = DirFromAngle(-ViewAngle / 2, false);
      Vector3 viewAngleB = DirFromAngle(ViewAngle / 2, false);

      Gizmos.color = Color.red;
      Gizmos.DrawLine(transform.position, transform.position + viewAngleA * ViewRadius);
      Gizmos.DrawLine(transform.position, transform.position + viewAngleB * ViewRadius);
   }

   private Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
   {
      if (!angleIsGlobal)
      {
         angleInDegrees += transform.eulerAngles.y;
      }

      return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
   }
}
