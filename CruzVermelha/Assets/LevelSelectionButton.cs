using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField]
    Level level;



    public void Select()
    {
        FindObjectOfType<LevelSelectionDirector>().SelectLevel(level);
    }
}
