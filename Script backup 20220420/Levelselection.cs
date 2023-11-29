using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Levelselection : MonoBehaviour
{
    public bool isUnlocked = false;//isUnlocked（是解鎖狀態）最初置false
    public float StageNum;
    public Image Lock;//綁定鎖的圖片，關卡解鎖後置false
    public Button ThisLevel;//綁定這一關的按鈕，關卡解鎖後置true
    private void Update()
    {
        UpdatelevelButton();//更新解鎖後的狀態
        Unlocklevel();
    }
    private void Start()
    {
        PlayerPrefs.SetInt("Lv0", 1);//設置lv0，要不然第一關找前一關的時候找不到
        ThisLevel = gameObject.GetComponent<Button>();
    }
    private void UpdatelevelButton()//更新解鎖後的狀態
    {
        if (isUnlocked)//解鎖後鎖的圖片關閉，按鈕設置可以按
        {
            Lock.gameObject.SetActive(false);
            ThisLevel.GetComponent<Button>().enabled = true;
        }
        else//否則鎖的圖片開?，按鈕設置不可以按
        {
            Lock.gameObject.SetActive(true);
            ThisLevel.GetComponent<Button>().enabled = false;
        }
    }
    private void Unlocklevel()
    {
     
            int previousLvIndex = int.Parse(gameObject.name) - 1;
            if (PlayerPrefs.GetInt("Lv" + previousLvIndex) > 0)
            {
                isUnlocked = true;
            }
        

    }
}
