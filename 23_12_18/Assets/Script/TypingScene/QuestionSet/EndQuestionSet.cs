using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

public class EndQuestionSet : QuestionSet{
    public EndQuestionSet(){
        Questions.Add(E_QuestionState.FIRST, Resources.Load<Question> ("Questions/EndQuestions/End_First"));
        Questions.Add(E_QuestionState.LATTER, Resources.Load<Question> ("Questions/EndQuestions/End_Latter"));
    }
}
