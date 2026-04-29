using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
   [SerializeField]
   private Transform _target;

   [SerializeField]
   private Vector3 _angle = new Vector3(20, 0, 0);

   private float _speed = 20;

   private void Update()
   {
      //if (Input.GetMouseButtonDown(0))
      //{
      //   _target.transform.Rotate(_angle);
      //}
      _target.transform.rotation *= Quaternion.Euler(_angle * _speed * Time.deltaTime);
   }
}