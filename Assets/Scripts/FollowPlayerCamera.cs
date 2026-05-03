using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
   public Transform Target;

   public Vector3 Offset = new Vector3(0, 2, -5);

   private void LateUpdate()
   {
      if (Target == null) return;

      transform.position = Target.position + Offset;
      transform.LookAt(Target);
   }
}
