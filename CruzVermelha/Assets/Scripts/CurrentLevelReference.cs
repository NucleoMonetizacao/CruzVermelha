
using UnityEngine;

[CreateAssetMenu(menuName = "CurrentLevelReference")]
public class CurrentLevelReference : ScriptableObject
{
    [SerializeField]
    Level value;
    public Level Value { get => value; }


    public void SetValueTo(Level x)
    {
        value = x;
    }
   
}
