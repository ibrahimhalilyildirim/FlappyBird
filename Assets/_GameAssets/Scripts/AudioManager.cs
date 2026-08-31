using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public AudioSource _wingSound; 
   public AudioSource _deadSound; 


   public void OnPressedForJump()
    {
        _wingSound.Play();
    }
}
