using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchcontrol : MonoBehaviour
{
    private Touch initTouch = new Touch();
    public Camera mainCam;

    private float rotX = 0f;
    private float rotY = 0f;
    private Vector3 origRot;

    public float rotSpeed = 0.2f;
    public float dir = -1;


    // Start is called before the first frame update
    void Start()
    {
        
        origRot = mainCam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;
                rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                rotY -= deltaX * Time.deltaTime * rotSpeed;
                rotX = Mathf.Clamp(rotX, -3f, 3f);
                rotY = Mathf.Clamp(rotY, -9f, 9f);
                mainCam.transform.eulerAngles = new Vector3(rotX, rotY, 0f)
                    ;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        
    }
}
