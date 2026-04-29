using UnityEngine;

public class VectorOper : MonoBehaviour
{
   private Vector2 _playerPosition = new Vector2(3, 1);

   private Vector2 _enemyPosition = new Vector2(1, 2);

   private Vector2 _findOfView = new Vector2(1, 1);

   private float _dotResult;

   private void Start()
   {
      _dotResult = Vector2.Dot(_findOfView, (_playerPosition - _enemyPosition));
   
      //print(_dotResult);
   }
}