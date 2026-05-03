using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager Instanse = null;

   public AudioSource MusicSource;

   private void Awake()
   {
      if (Instanse == null)
      {
         Instanse = this;
      }
      else if (Instanse == false)
      {
         Destroy(gameObject);
      }

      DontDestroyOnLoad(gameObject);
   }
}
