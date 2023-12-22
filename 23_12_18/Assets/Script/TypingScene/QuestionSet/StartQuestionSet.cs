using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestionSet : QuestionSet{
    public StartQuestionSet(){
        Questions[E_QuestionState.FIRST] = Resources.Load<Question> ("Questions/StartQuestions/Start_First");
        Questions[E_QuestionState.LATTER] = Resources.Load<Question> ("Questions/StartQuestions/Start_Latter");
    }
}
