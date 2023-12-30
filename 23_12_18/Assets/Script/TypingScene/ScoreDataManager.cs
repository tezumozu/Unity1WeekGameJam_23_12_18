using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDataManager : MonoBehaviour{

    [SerializeField]
    private List<ScoreData> list;

    private static List<ScoreData> staticlist;

    public static Dictionary<E_Evaluation,int> GetDic{
        get{
            var dic = new Dictionary<E_Evaluation,int>();

            foreach (var data in staticlist){
                dic.Add(data.Evaluation,data.Score);
            }

            return dic;
        }
    }

    void Awake () {
        staticlist = list;
    }
}

[System.Serializable]
public class ScoreData{

    [SerializeField]
    public int Score;

    [SerializeField]  
    public E_Evaluation Evaluation;
}
