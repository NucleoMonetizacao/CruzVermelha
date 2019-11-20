
using UnityEngine;

[CreateAssetMenu(menuName = "CurrentPatientReference")]
public class CurrentPatientReference : ScriptableObject
{
    [SerializeField]
    Patient value;
    public Patient Value { get => value; }


    public void SetValueTo(Patient x)
    {
        value = x;
    }

}
