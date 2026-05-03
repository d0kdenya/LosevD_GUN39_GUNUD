using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
   public AudioMixer AudioMixer;

   public float ReverbTime;

   private void Update()
   {
      AudioMixer.SetFloat("ReverbTime", ReverbTime);

      float currentReverbTime;
      AudioMixer.GetFloat("ReverbTime", out currentReverbTime);

      Debug.Log(currentReverbTime);

      if (Input.GetKeyDown(KeyCode.Space))
      {
         float newReverbTime = Random.Range(1f, 100f);
         AudioMixer.SetFloat("ReverbTime", newReverbTime);
      }
   }
}
