using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public Sound[] sounds;
    
   private void Awake()
   {
       if (Instance == null)
       {
           Instance = this;
       }
       else
       {
           Destroy(gameObject);
           return;
       }
       
       
       DontDestroyOnLoad(gameObject);
       
       foreach (Sound s in sounds)
       {
        s.audioSource = gameObject.AddComponent<AudioSource>();
        s.audioSource.clip = s.clip;
        
        s.audioSource.volume = s.volume;
        s.audioSource.pitch = s.pitch;
        s.audioSource.playOnAwake = s.playOnAwake;
        s.audioSource.loop = s.loop;
       }
   }

   private void Start()
   {
       Play("MainMusic");
   }

   public void Play(string name)
   {
       Sound s = Array.Find(sounds, sound => sound.name == name);
     
     if (s == null)
     {
         Debug.LogError($"sound {name} is not found");
         return;
     }
         
     s.audioSource.Play();
   }
}
