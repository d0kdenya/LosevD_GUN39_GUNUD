using UnityEngine;

public class Building : MonoBehaviour
{
   [SerializeField]
   private Vector2Int _size = Vector2Int.one;

   private Renderer _renderer;

   public Vector2Int Size => _size;

   private void Awake()
   {
      _renderer = GetComponentInChildren<Renderer>();
   }

   public void SetTransparent(bool available)
   {
      if (available)
      {
         _renderer.material.color = Color.green;
      }
      else
      {
         _renderer.material.color = Color.red;
      }
   }

   public void SetNormal()
   {
      _renderer.material.color = Color.white;
   }

   private void OnDrawGizmos()
   {
      for (int x = 0; x < _size.x; x++)
      {
         for (int y = 0; y < _size.y; y++)
         {
            if ((x + y) % 2 == 0)
            {
               Gizmos.color = new Color(0.88f, 1f, 0.3f);
            }
            else
            {
               Gizmos.color = new Color(1f, 0.68f, 0.3f);
            }
            Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
         }
      }
   }
}
