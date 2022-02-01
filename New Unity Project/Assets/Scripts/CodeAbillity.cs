using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeAbillity : MonoBehaviour
{
    //the bottuns
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;

    //raycast
    RaycastHit push;
    float maxDistance;
    public GameObject Camera;
    Vector3 origin;
    public GameObject WandCrystal;


    bool isNoPick;
    bool isCorrect1;
    bool isCorrect2;
    bool isCorrect3;
    bool isCorrect4;
    bool isWin;
    bool isSound;
    bool isCoding;


    public GameObject door;


    //Sound
    public AudioSource audioSource;
    public AudioClip Correct;
    public AudioClip Beep;
    public AudioClip wrong;


    void Start()
    {
        maxDistance = 10f;
        isWin = false;
        isNoPick = true;
        isCorrect1 = false;
        isCorrect2 = false;
        isCorrect3 = false;
        isCorrect4 = false;
    }

    void Update()
    {

        origin = Camera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(origin, Camera.transform.forward * maxDistance);
            if (Physics.Raycast(origin, Camera.transform.forward, out push, maxDistance))
            {
                //first botton
                if ((push.collider.tag == "First") && isNoPick == true)
                {
                    isNoPick = false;
                    isCorrect1 = true;
                }
                //second bottun
                if ((push.collider.tag == "Second") && isCorrect1 == true)
                {
                    isCorrect2 = true;
                }
                //third bottun
                if ((push.collider.tag == "Third") && isCorrect2 == true)
                {
                    isCorrect3 = true;
                }
                //fourth bottun
                if ((push.collider.tag == "Fourth") && isCorrect3 == true)
                {
                    isCorrect4 = true;
                }
                
               if (isCorrect1 && isCorrect2 && isCorrect3 && isCorrect4 == true)
               {
                    isWin = true;
               }
                if (push.collider.tag == "Button2" && isWin == true)
                {
                    audioSource.PlayOneShot(Correct);
                    Destroy(door, 0.2f);
                }
                if (push.collider.tag == "Button2" && isWin == false)
                {
                    audioSource.PlayOneShot(wrong);
                    isNoPick = true;
                }
                if ((push.collider.tag == "First") || (push.collider.tag == "Second") || (push.collider.tag == "Third") || (push.collider.tag == "Fourth"))
                {
                    audioSource.PlayOneShot(Beep);
                }


            }

        }
    
    }


}
