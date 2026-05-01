using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField]
   private Ball _ball;

   [SerializeField]
   private Transform _throwPoint;

   private void Awake()
   {
      Ball ball = Instantiate(_ball, _throwPoint);

      ball.Init(_throwPoint);
   }
}
