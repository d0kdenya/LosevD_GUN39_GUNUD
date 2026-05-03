using UnityEngine;

public class FootSteps : MonoBehaviour
{
   public CharacterController CharacterController;

   public AudioSource AudioSource;

   public float StepInterval = 0.5f;

   public AudioClip[] DefaultFootstepSounds;

   private float _nextStepTime;

   private Vector3 _lastPosition;

   private void Start()
   {
      CharacterController = GetComponent<CharacterController>();
      AudioSource = GetComponent<AudioSource>();

      if (CharacterController == null)
      {
         Debug.LogError("CharacterController не найден!");
         enabled = false;
      }

      if (AudioSource == null)
      {
         Debug.LogError("AudioSource не найден!");
         enabled = false;
      }

      _nextStepTime = Time.time;
      _lastPosition = transform.position;
   }

   private void Update()
   {
      float distanceMoved = Vector3.Distance(transform.position, _lastPosition);

      if (distanceMoved > 0.1f && CharacterController.isGrounded)
      {
         if (Time.time >= _nextStepTime)
         {
            PlayFootstepSound();
            _nextStepTime = Time.time + StepInterval;
         }
      }
      _lastPosition = transform.position;
   }

   void PlayFootstepSound()
   {
      if (DefaultFootstepSounds.Length == 0) return;

      AudioClip clip = DefaultFootstepSounds[Random.Range(0, DefaultFootstepSounds.Length)];
   
      AudioSource.PlayOneShot(clip);
   }
}
