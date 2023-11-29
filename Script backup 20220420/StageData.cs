using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageData : MonoBehaviour
{
    public static int StagedataVar;
    public int StageNum;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("StagedataVar", StageNum);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
