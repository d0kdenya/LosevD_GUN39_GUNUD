using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   [SerializeField]
   private Transform _target;

   [SerializeField]
   private List<Transform> _enemy;

   [SerializeField]
   private float _radius;

   private void Update()
   {
      float angleStep = 360 / _enemy.Count;

      //print("angleStep: " + angleStep);
      //print("_enemy.Count: " + _enemy.Count);

      for (int i = 0; i < _enemy.Count; i++)
      {
         float angle = angleStep * i;
         Vector2 localPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * _radius;

         _enemy[i].position = new Vector3(_target.position.x + localPosition.x, _target.position.y + localPosition.y, _target.position.z + localPosition.y);
      }
   }
}
