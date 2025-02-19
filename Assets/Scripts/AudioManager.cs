using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    private AudioSource fxSource;
    [SerializeField]
    private AudioClip[] audioClips;
    private bool isPlayingFX = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public bool HasPlayedFX()
    {
        return isPlayingFX;
    }
    
    public void SetPlayingFX(bool value)
    {
        isPlayingFX = value;
    }
    private void Start()
    {
        isPlayingFX = true;
    }
    
    public void PlayJumpClip()
    {
        fxSource.clip = audioClips[0];
        fxSource.Play();
    }
    
    public void PlayTapClip()
    {
        fxSource.clip = audioClips[1];
        fxSource.Play();
    }
    
    public void PlayCrackEggClip()
    {
        fxSource.clip = audioClips[2];
        fxSource.Play();
    }
    
    public void PlayHurtClip()
    {
        fxSource.clip = audioClips[3];
        fxSource.Play();
    }
}
