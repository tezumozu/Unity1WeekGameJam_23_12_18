using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuestionSet : QuestionSet{
    public EndQuestionSet(){
        Questions[E_QuestionState.FIRST] = Resources.Load<Question> ("Questions/EndQuestion/End_FirstQuestion");
        Questions[E_QuestionState.FIRST] = Resources.Load<Question> ("Questions/EndQuestion/End_LatterQuestion");
    }
}
