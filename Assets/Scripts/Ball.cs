using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
   [SerializeField, Range(1, 1000)]
   private float _force = 5f;

   [SerializeField, Range(1, 200)]
   private float _speed = 5f;

   private Rigidbody _body;

   private Status _status = Status.Aiming;

   private float _trajectoryLimit = 8.5f;

   private Transform _throwPoint;

   private bool _isShooting;

   private void Awake()
   {
      _body = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      if (_status != Status.Aiming)
      {
         return;
      }

      if (Input.GetKeyDown(KeyCode.Space))
      {
         _isShooting = true;
      }
   }

   private void FixedUpdate()
   {
      if (_status == Status.Aiming)
      {
         float dx = 0f;

         if (Input.GetKey(KeyCode.A))
         {
            dx += 1f;
         }
         if (Input.GetKey(KeyCode.D))
         {
            dx -= 1f;
         }

         if (dx != 0f)
         {
            Vector3 p = _body.position;
            p.x += dx * _speed * Time.fixedDeltaTime;
            p.x = Mathf.Clamp(p.x, -_trajectoryLimit, _trajectoryLimit);
            _body.MovePosition(p);
         }
         if (_isShooting)
         {
            _isShooting = false;
            Launch();
         }
      }
   }

   public void Init(Transform throwPoint)
   {
      _throwPoint = throwPoint;

      _status = Status.Aiming;
      _body.isKinematic = true;

      _body.velocity = Vector3.zero;
      _body.angularVelocity = Vector3.zero;
   }

   private void Launch()
   {
      if (_throwPoint == null)
         return;
      _status = Status.Throwing;
      _body.isKinematic = false;

      _body.velocity = Vector3.zero;
      _body.angularVelocity = Vector3.zero;
      
      _body.AddForce(_throwPoint.forward * _force, ForceMode.Impulse);
   }
}
