using UnityEngine;
using static UnityEngine.UI.Image;

public class EnemyScript : MonoBehaviour
{
   [SerializeField]
   private Transform _target;

   public Transform Target => _target;

   [SerializeField, Range(0, 20)]
   private float _viewRadius = 10f;

   public float ViewRadius => _viewRadius;

   [SerializeField, Range(0, 360)]
   private float _viewAngle = 90f;

   public float ViewAngle => _viewAngle;

   [SerializeField]
   private Vector3 _viewCenter;

   public Vector3 ViewCenter => _viewCenter;

   private void Update()
   {
      Vector3 ViewOrigin = transform.position + _viewCenter;
      //Vector3 worldViewOrigin = transform.TransformPoint(ViewOrigin);

      var distance = Vector3.Distance(ViewOrigin, _target.position);

      if (distance < _viewRadius)
      {
         Vector3 dirToTarget = (_target.position - ViewOrigin).normalized;

         if (Vector3.Angle(transform.forward, dirToTarget) < _viewAngle / 2)
         {
            Debug.Log("Игрок обнаружен!");
         }
      }
   }
}
