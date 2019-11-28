
using UnityEngine;

[CreateAssetMenu(menuName = "BoolReference")]
public class BoolReference : ScriptableObject
{
    public bool value = false;

    public void SetValueTo(bool x)
    {
        value = x;
    }
}
