using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
   [SerializeField]
   private Transform _target;

   [SerializeField]
   private Vector3 _offset;

   [SerializeField]
   private Image _foreground;

   [SerializeField]
   private Image _background;

   private void LateUpdate()
   {
      Vector3 direction = (_target.position - Camera.main.transform.position).normalized;
      bool isBehind = Vector3.Dot(direction, Camera.main.transform.forward) <= 0;
      _foreground.enabled = !isBehind;
      _background.enabled = !isBehind;
   }

   public void SetHealthBarPercentage(float percentage)
   {
      float parentWidth = GetComponent<RectTransform>().rect.width;
      float width = parentWidth * percentage;
      _foreground.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
   }
}
