using UnityEngine;

public class ChangeColorCurve : MonoBehaviour
{
   [SerializeField]
   private Transform _target;

   [SerializeField]
   private AnimationCurve _animCurve;

   [SerializeField]
   private float _minDistace = 5f;

   private Renderer _renderer;

   private void Start()
   {
      _renderer = GetComponent<Renderer>();
      _renderer.material.color = new Color(0, 0, 0);
   }

   private void Update()
   {
      float distance = Vector3.Distance(transform.position, _target.position);

      if (distance < _minDistace)
      {
         float redColor = _animCurve.Evaluate(1 - distance / _minDistace);

         _renderer.material.color = new Color(redColor, 0, 0);
      }
   }
}
