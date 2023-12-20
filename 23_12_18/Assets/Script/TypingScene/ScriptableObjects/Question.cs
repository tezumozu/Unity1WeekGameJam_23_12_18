using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Question Data", fileName = "QuestionData")]
public class Question : ScriptableObject{
    [SerializeField]
    public string QuestionText;

    [SerializeField]
    public string Spell;

    [SerializeField]
    public float Time;

    [SerializeField]
    public E_Voice VoiceFileName;
}
