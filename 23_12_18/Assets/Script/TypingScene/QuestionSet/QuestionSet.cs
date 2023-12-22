using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestionSet {
    protected static SynchronizationContext context;

    public Dictionary<E_QuestionState,Question> Questions;

    public QuestionSet(){
        Questions = new Dictionary<E_QuestionState, Question>();
    }

    public static void SetSynchronizationContext(SynchronizationContext synchronizationContext){
        context = synchronizationContext;
    }
}
