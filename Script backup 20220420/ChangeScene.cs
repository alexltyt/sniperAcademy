using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public float loadDelay = 0;
    public string sceneName;
    public int Stagelock;
    //public GameObject button;
    public Button button;

    void Start()
    {
        //Debug.Log(Scope.stage);
        button = GetComponent<Button>();
        //if (Scope.stage >= Stagelock)
        //{
        //    button.interactable = true;
        //}
        //else
        //{
        //    button.interactable = false;
        //}
    }
    public void LoadScene()
    {
      
            UnityEngine.EventSystems.EventSystem.current.enabled = false;
            Invoke("StartLoadScene", loadDelay);
    
        
        
    }

    void StartLoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

