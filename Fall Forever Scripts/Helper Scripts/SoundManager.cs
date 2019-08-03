using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    [SerializeField] // Show up in inspector
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip landClip = null, deathClip = null, iceBreakClip = null, gameOverClip = null, bounceClip = null;
        
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    public void LandSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void IceBreakSound()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }

    public void DeathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void GameOverSound()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }

    public void BounceSound()
    {
        soundFX.clip = bounceClip;
        soundFX.Play();
    }
}
