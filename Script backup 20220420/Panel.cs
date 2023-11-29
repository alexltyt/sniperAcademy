using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    //public GameObject panel;
    //public GameObject Lpanel;
    public GameObject[] potentialTargets;
    public static int enemycount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        potentialTargets = GameObject.FindGameObjectsWithTag("Enemy");
        enemycount = potentialTargets.Length;
     
        if (potentialTargets.Length == 0)
        {
            //Time.timeScale = 0;
            //panel.SetActive(true);
        }

        
       
    }
}
