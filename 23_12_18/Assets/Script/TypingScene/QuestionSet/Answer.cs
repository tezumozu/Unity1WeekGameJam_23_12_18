using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer{
    public bool IsClear;
    public Question Question;
    public float Time;
    public E_Evaluation Evaluation;

    public Answer(Question question, bool isClear, float time,E_Evaluation evaluation){
        IsClear = isClear;
        Question = question;
        Time = time;
        Evaluation = evaluation;
    }
}
