using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxOutput;
    public static AudioManager Instance {get; private set;}
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    public void PlaySFX(AudioClip clip)
    {
        sfxOutput.PlayOneShot(clip);
    }
}
