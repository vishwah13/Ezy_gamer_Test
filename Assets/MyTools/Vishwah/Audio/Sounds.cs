﻿using UnityEngine;

[System.Serializable]
public class Sound
{
   public string name;
   public AudioClip clip;
   
   [Range(0f,1f)]
   public float volume;

   [Range(0f,3f)]
   public float pitch;

   [HideInInspector] 
   public AudioSource audioSource;

   public bool playOnAwake;
   public bool loop;



}
