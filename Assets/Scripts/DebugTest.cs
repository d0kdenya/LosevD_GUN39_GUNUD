using UnityEngine;

public class DebugTest : MonoBehaviour
{
   private int _countFrame = 0;

   private void Start()
   {
      Debug.Log("Работаем");
   }

   private void Update()
   {
      _countFrame += 1;

      if (Input.GetKeyDown(KeyCode.Space))
      {
         Debug.Log("Прошло кадров после старта: " + _countFrame);
         Debug.DrawLine(Vector3.zero, new Vector3(5, 4, 0), Color.red, 2.5f);
      }

      Debug.DrawRay(new Vector3(1, -1, 0), new Vector3(5, 4, 0), Color.blue);
   }
}
