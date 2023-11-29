using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZObjectPools;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCam;
    public float scopedFOV = 15f;
    private float normalFOV = 60f;
    private bool isScoped = false;
    private bool allowScoped = true;

    private Touch initTouch = new Touch();
  
    private float rotX = 0f;
    private float rotY = 0f;
    private Vector3 origRot;

    public float rotSpeed = 0.05f;
    public float dir = -1;

    public Transform shootPoint;
    public AudioClip shootSound;
    public EZObjectPool bulletPool;
    public float damage = 30f;
    public float range = 500f;
    public float speed = 20;
    public GameObject bullet;
    AudioSource AS;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce;
    private float nextTimeToFire = 0f;
    public GameObject panel;
    public GameObject Lpanel;
    public static float headshotCount;
    public static float hitTarget;
    public static int totalShot;

    GameObject[] AmmoBG = new GameObject[10];
    GameObject[] Ammo = new GameObject[10];
    GameObject AmmoUI;
    GameObject Ammos;
    public static int AmmoNum = 6;
    int currentAmmo;
    public int stage = 1;
    public static int StageUnlock;
    private float enemies;

    public Text missed;



    private void Start()
    {
        StageUnlock = stage + 1;
        Ammos = GameObject.Find("AmmoBG");
        AmmoUI = Ammos.transform.parent.gameObject;
        currentAmmo = AmmoNum;
        AmmoBG[0] = Ammos;
        Ammo[0] = AmmoBG[0].transform.GetChild(0).gameObject;

        for (int i = 1; i < AmmoNum; i++)
        {
            AmmoBG[i] = Instantiate(Ammos, AmmoUI.transform);
            Ammo[i] = AmmoBG[i].transform.GetChild(0).gameObject;
        }
        
        headshotCount = 0;
        hitTarget = 0;
        totalShot = 0;
        AS = GetComponent<AudioSource>();


        //animator.SetBool("Scoped", isScoped);
        origRot = mainCam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
         //find gameobjects with the tag "enemy" (you must therefore tag the enemies with "enemy"
    }
    void Update()
    {

        //print(GameObject.FindGameObjectsWithTag("Enemy").Length);
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        CheckFinish();
        foreach (Touch touch in Input.touches)
        if (touch.phase == TouchPhase.Began && allowScoped == true)
        {
            initTouch = touch;
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);
                



            if (isScoped)
                StartCoroutine(OnScope());
      
        }
        else if (touch.phase == TouchPhase.Moved)
        {
                float deltaX = initTouch.position.x - touch.position.x;
            float deltaY = initTouch.position.y - touch.position.y;
            rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
            rotY -= deltaX * Time.deltaTime * rotSpeed;
            rotX = Mathf.Clamp(rotX, -3f, 3f);
            rotY = Mathf.Clamp(rotY, -9f, 9f);
            mainCam.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
        }
        else if (touch.phase == TouchPhase.Ended && allowScoped == false) //Time.time >= nextTimeToFire)
        {
            initTouch = new Touch();
                Shoot();
                Invoke ("OnUnscoped",2f);
            }


    }
    void CheckFinish()
    {
        if (enemies == 0)
        {
            panel.SetActive(true);
            PlayerPrefs.SetInt("Lv" + stage, StageUnlock);
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefsLv:  " + PlayerPrefs.GetInt("Lv" + stage));
        }
        else if (currentAmmo == 0 && enemies != 0)
        {
            Debug.Log("try again");
            Lpanel.SetActive(true);
            //Time.timeScale = 0;

        }
    }
    void Shoot()
    {
        nextTimeToFire = Time.time + 1f;
        totalShot += 1;
        currentAmmo--;
        Ammo[currentAmmo].SetActive(false);
        Debug.Log("currentAmmo:  "+currentAmmo);
        Debug.Log("enemycount:  "+ enemies);

        
        AS.PlayOneShot(shootSound);
        muzzleFlash.Play();
        RaycastHit hit;
        
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
            {
           
            
            Target target = hit.transform.GetComponentInChildren<Target>();
           
            if (hit.collider.CompareTag("Body"))
            {
                target.Takedamage(damage);
                hitTarget += 1;
            }
            else if (hit.collider.CompareTag("Headshot"))
            {
                headshotCount += 1;
                hitTarget += 1;
                target.Takedamage(damage * 2);
                target.HS.enabled = true;
                Debug.Log("headshotCoun:  "+headshotCount);

            }
            else
            {
                Debug.Log("missed");
                Missed();

            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal * impactForce);
               
            }
            GameObject impactGO =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
            Debug.Log("hit on:  "+hit.transform.name);
            Debug.Log("collider:  "+hit.collider.tag);
            
        }
    }


    void OnUnscoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        mainCam.fieldOfView = normalFOV;
        isScoped = !isScoped;            ;
        allowScoped = true;
        animator.SetBool("Scoped", isScoped);
    }
    IEnumerator OnScope()
    {
        yield return new WaitForSeconds(0.2f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        //normalFOV = mainCam.fieldOfView;
        mainCam.fieldOfView = scopedFOV;
        allowScoped = false;
    }

    IEnumerator Missed()
    {
        yield return new WaitForSeconds(1f);
        missed.enabled=true;
        //yield return new WaitForSeconds(1f);
        //missed.enabled = false;
    }
}
