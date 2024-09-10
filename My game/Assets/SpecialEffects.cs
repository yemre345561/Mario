using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour
{
    public static SpecialEffects specialEffects { get; private set; }
    private GameObject smokeVFX;
    private AudioClip coinSFX;

    private void Awake()
    {
        if (specialEffects != null && specialEffects != this)
        {
            Destroy(this);
        }
        else
        {
            specialEffects = this;
        }
    }

    private void Start()
    {
        smokeVFX = Resources.Load<GameObject>("SmokeVFX");
        coinSFX = Resources.Load<AudioClip>("CoinSFX");
    }

    public void CreateSmoke(Transform _transform)
    {
        GameObject smoke = Instantiate(smokeVFX, _transform.position, Quaternion.identity);
        Destroy(smoke.gameObject, smoke.GetComponent<ParticleSystem>().main.duration);
    }

    public void CoinSFX()
    {
        // Create a temporary GameObject to play the sound
        GameObject speaker = new GameObject();
        AudioSource audioSource = speaker.gameObject.AddComponent<AudioSource>();
        audioSource.clip = coinSFX;

        // Play the audio clip
        audioSource.Play();

        // Destroy the temporary GameObject after the audio clip length
        float sfxLength = coinSFX.length;
        Destroy(speaker.gameObject, sfxLength);
    }
}

