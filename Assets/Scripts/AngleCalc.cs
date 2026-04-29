using UnityEngine;

public class AngleCalc : MonoBehaviour
{
   [SerializeField]
   private Transform _targetOne;

   [SerializeField]
   private Transform _targetTwo;

   private Vector3 _direction;

   private float _angle;

   private void Update()
   {
      _direction = _targetTwo.position - _targetOne.position;
      _angle = Vector3.Angle(transform.forward, _direction);

      //print(transform);
      //print(transform.forward);
      //print(_angle);
   }
}
