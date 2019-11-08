using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    private static AudioPlayer instance;

    [SerializeField]
    SoundList soundList;

    [SerializeField]
    private AudioSource audioSource;

    public static AudioPlayer Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<AudioPlayer>();
                if(instance == null)
                {
                    Debug.LogError("Missing AudioPlayer in scene");
                }
            }
            return instance;
        }

    }


    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    public static void PlaySound(int soundIndex)
    {
        Instance.PlaySoundOneShot(soundIndex);
    }

    private void PlaySoundOneShot(int index)
    {
#if UNITY_EDITOR
        if(index >= soundList.List.Count)
        {
            Debug.LogError("Trying to play sound with index bigger than SoundList count");
        }

#endif
        audioSource.PlayOneShot(soundList.List[index].AudioClip);
    }



}
