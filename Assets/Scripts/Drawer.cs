using UnityEditor;
using UnityEngine;

public class Drawer : MonoBehaviour
{
   [SerializeField]
   private Points[] _points;

   [SerializeField]
   private bool _isDraw;

   [SerializeField]
   private bool _isCalc;

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.yellow;

      var camera = SceneView.currentDrawingSceneView.camera;

      for (int i = 0; i < _points.Length; i++)
      {
         _points[i].transform.LookAt(camera.transform.position);
         //_points[i].ChangeText($"{i} - {_points[i].transform.position}");

         Gizmos.DrawLine(Vector3.zero, _points[i].transform.position);
      }

      if (_isDraw)
      {
         Drawing();
      }
      if (_isCalc)
      {
         Calc();
      } 
   }

   private void Calc()
   {
      Gizmos.color = Color.red;
      var result = _points[0].transform.position + _points[1].transform.position;
      Gizmos.DrawLine(_points[0].transform.position, result);

      Gizmos.color = Color.blue;
      //_points[2].Object.transform.position = result;
      Gizmos.DrawLine(Vector3.zero, result);
   }

   private void Drawing()
   {
      Gizmos.color = Color.green;

      var size = _points.Length;

      for (int i = 0; i < size - 1; i++)
      {
         Gizmos.DrawLine(_points[i].transform.position, _points[i + 1].transform.position);
      }
      Gizmos.DrawLine(_points[size - 1].transform.position, _points[0].transform.position);
   }
}
