using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSet {
    public Dictionary<E_QuestionState,Question> Questions;

    public QuestionSet(){
        Questions = new Dictionary<E_QuestionState, Question>();
    }
}
