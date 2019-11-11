using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Case")]
[Serializable]
public class Case : ScriptableObject
{
    public bool heartAttack = false;
    public bool burnInLeftHand = false;
    public bool choking = false;

}
