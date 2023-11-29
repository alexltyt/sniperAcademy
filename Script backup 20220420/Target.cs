using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float maxHealth = 50f;
    public Animator animator;
    public Image HPBar;
    public Image HS;


    private void Start()
    {
        animator = GetComponent<Animator>();
        HS.enabled = false;

        var transform = GetComponentsInChildren<Transform>();
        foreach(var tran in transform)
        {
            if(tran.name == "HPBar")
            {
                HPBar = tran.GetComponent<Image>();
                HPBar.fillAmount = 1;
            }
        }
    }
    
    public void Takedamage(float amount)
    { 
        Debug.Log(amount);
        health -= amount;
        if (HPBar) HPBar.fillAmount = health/maxHealth;
        if (health <= 0f)
        {
            Die();
            
        }
    }

    void Die()
    {
        animator.SetBool("die", true);
        if (HPBar) HPBar.transform.parent.gameObject.SetActive(false);
        Destroy(gameObject,2f);

    }
    // Start is called before the first frame update

   
}
