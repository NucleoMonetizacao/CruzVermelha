using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Case")]
[Serializable]
public class Case : ScriptableObject
{
    public bool isDead = false;

    public bool heartAttack = false;
    public bool burnInLeftHand = false;
    public bool choking = false;

    //Informações que o jogador tem na prancheta
    public bool? breathing = null;
    public bool? conciouss = null;
    public bool? bleeding = null;
    public bool? burn = null;
    public bool? desiresHelp = null;
    public bool? fractures = null;

    public bool examinationComplete = false;
    public bool completeClipboardChecked = false;
    public bool headExamined = false;
    public bool rightHandExamined = false;
    public bool leftHandExamined = false;
    public bool chestExamined = false;

    public bool calledHelp = false;
    public bool policeCalled = false;
    public bool fireDepartmentCalled = false;
    public bool ambulanceCalled = false;

}
