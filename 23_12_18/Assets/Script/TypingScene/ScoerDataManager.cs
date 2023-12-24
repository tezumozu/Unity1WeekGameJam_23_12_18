using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoerDataManager : MonoBehaviour{

    [SerializeField]
    private List<ScoerData> list;

    private static List<ScoerData> staticlist;

    public static Dictionary<E_Evaluation,int> GetDic{
        get{
            var dic = new Dictionary<E_Evaluation,int>();

            foreach (var data in staticlist){
                dic.Add(data.Evaluation,data.Scoer);
            }

            return dic;
        }
    }

    void Awake () {
        staticlist = list;
    }
}

[System.Serializable]
public class ScoerData{

    [SerializeField]
    public int Scoer;

    [SerializeField]  
    public E_Evaluation Evaluation;
}
