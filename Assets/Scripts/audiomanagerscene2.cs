using UnityEngine.Audio;
using System;
using UnityEngine;

public class audiomanagerscene2 : MonoBehaviour
{
    public sound[] Sounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foreach(sound s in Sounds) {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip=s.clip;
            s.source.volume=s.volume;
            s.source.pitch=s.pitch;
        }
        
    }

   public void Play(string name) { 
        sound s = Array.Find(Sounds,Sound=>Sound.name==name);
        s.source.Play();
    }
}
