using UnityEngine;

public class FOVController : MonoBehaviour
{
   public Camera MainCamera;

   public float FOVSpeed = 10f;

   private void Update()
   {
      if (Input.GetKey(KeyCode.Q))
      {
         MainCamera.fieldOfView -= FOVSpeed * Time.deltaTime;
      }
      if (Input.GetKey(KeyCode.E))
      {
         MainCamera.fieldOfView += FOVSpeed * Time.deltaTime;
      }
      MainCamera.fieldOfView = Mathf.Clamp(MainCamera.fieldOfView, 10, 179);
   }
}
