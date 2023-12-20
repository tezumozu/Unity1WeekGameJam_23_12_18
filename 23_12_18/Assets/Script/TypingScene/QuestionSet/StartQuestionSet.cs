using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestionSet : QuestionSet{
    public StartQuestionSet(){
        Questions[E_QuestionState.FIRST] = Resources.Load<Question> ("Questions/StartQuestion/Start_FirstQuestion");
        Questions[E_QuestionState.FIRST] = Resources.Load<Question> ("Questions/StartQuestion/Start_LatterQuestion");
    }
}
