using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public CharacterController CharacterController;

   public float Speed = 5.0f;

   public float Gravity = -9.81f;

   public float JumpHeight = 3.0f;

   private Vector3 _velocity;

   private void Start()
   {
      CharacterController = GetComponent<CharacterController>();

      if (CharacterController == null)
      {
         Debug.LogError("CharacterController не найден!");
         enabled = false;
      }
   }

   private void Update()
   {
      float x = Input.GetAxis("Horizontal");
      float z = Input.GetAxis("Vertical");

      Vector3 move = transform.right * x + transform.forward * z;
      move = Vector3.ClampMagnitude(move, 1.0f);

      CharacterController.Move(move * Speed * Time.deltaTime);

      //if (CharacterController.isGrounded)
      //{
      //   _velocity.y = 0f;

      //   //   if (Input.GetButtonDown())
      //   //   {
      //   //      _velocity.y = Mathf.Sqrt(JumpHeight * 2f * -Gravity);
      //   //   }
      //}

      _velocity.y += Gravity * Time.deltaTime;
      CharacterController.Move(_velocity * Time.deltaTime);
   }
}
