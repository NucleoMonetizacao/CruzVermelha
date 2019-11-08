using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SoundList")]
public class SoundList : ScriptableObject
{
    [SerializeField]
    List<Sound> list;

    public List<Sound> List { get => list; }




    [System.Serializable]
    public class Sound
    {

        [SerializeField]
        AudioClip audioClip;

        public AudioClip AudioClip { get => audioClip; }

       

#if UNITY_EDITOR
        [SerializeField]
        string name;

        [SerializeField] [TextArea]
        string devNote;
#endif

    }

}
