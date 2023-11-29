using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Levelselection : MonoBehaviour
{
    public bool isUnlocked = false;//isUnlocked�]�O���ꪬ�A�^�̪�mfalse
    public float StageNum;
    public Image Lock;//�j�w�ꪺ�Ϥ��A���d�����mfalse
    public Button ThisLevel;//�j�w�o�@�������s�A���d�����mtrue
    private void Update()
    {
        UpdatelevelButton();//��s����᪺���A
        Unlocklevel();
    }
    private void Start()
    {
        PlayerPrefs.SetInt("Lv0", 1);//�]�mlv0�A�n���M�Ĥ@����e�@�����ɭԧ䤣��
        ThisLevel = gameObject.GetComponent<Button>();
    }
    private void UpdatelevelButton()//��s����᪺���A
    {
        if (isUnlocked)//������ꪺ�Ϥ������A���s�]�m�i�H��
        {
            Lock.gameObject.SetActive(false);
            ThisLevel.GetComponent<Button>().enabled = true;
        }
        else//�_�h�ꪺ�Ϥ��}?�A���s�]�m���i�H��
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
