using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public int soundSourceSize;
    private List<AudioSource> soundSources;

    // Start is called before the first frame update
    void Start()
    {
        soundSources = new List<AudioSource>();

        for (int i = 0; i < soundSourceSize; i++){
            AudioSource newSoundSource = MakeNewSoundSource();
            soundSources.Add(newSoundSource);
        }
    }

    // Update is called once per frame
    public void PlaySound(AudioClip clip, float volume){
        foreach (AudioSource a in soundSources){
            if (!a.isPlaying){
                a.clip = clip;
                a.volume = volume;
                a.Play();
                return;
            }
        }
        AudioSource newSoundSource = MakeNewSoundSource();
        newSoundSource.clip = clip;
        newSoundSource.volume = volume;
        newSoundSource.Play();
        soundSources.Add(newSoundSource);
    }

    AudioSource MakeNewSoundSource(){
        GameObject sound = new GameObject("Sound Source");
        sound.AddComponent<AudioSource>();
        sound.transform.parent = this.transform;

        return sound.GetComponent<AudioSource>();
    }
}
