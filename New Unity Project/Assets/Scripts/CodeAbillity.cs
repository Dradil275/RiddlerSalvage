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
    //health
    public GameObject Health;

    //raycast
    RaycastHit push;
    float maxDistance;
    public GameObject Camera;
    Vector3 origin;
    public GameObject WandCrystal;

    // Health
  

    bool isNoPick;
    bool isWin;
    bool isSound;
    bool isCoding;

    string i;
    string CodeAnswer;
    

    public GameObject door;


    //Sound
    public AudioSource audioSource;
    public AudioClip Correct;
    public AudioClip Beep;
    public AudioClip wrong;
    public AudioClip fuck;

    void Start()
    {
        isCoding = true;
        CodeAnswer = null;
        maxDistance = 10f;
        isWin = false;
        isNoPick = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            audioSource.PlayOneShot(fuck);
        }
        origin = Camera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(origin, Camera.transform.forward * maxDistance);
            if (Physics.Raycast(origin, Camera.transform.forward, out push, maxDistance))
            {
                //first botton
                if ((push.collider.tag == "First") && isNoPick == true && isCoding == true)
                {
                    Getnumbers("1");
                    isNoPick = false;
                   
                }
                //second bottun
                if ((push.collider.tag == "Second")  && isCoding == true)
                {
                    Getnumbers("3");
                    
                }
                //third bottun
                if ((push.collider.tag == "Third")  && isCoding == true)
                {
                    Getnumbers("4");
                    
                }
                //fourth bottun
                if ((push.collider.tag == "Fourth")  && isCoding == true)
                {
                    Getnumbers("2");
                    
                }
                
               if (CodeAnswer == "1342" && isCoding == true)
               {
                    Debug.Log("code correct");
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
                    Health.GetComponent<Playerhealth>().TakeDamage();
                    Health.GetComponent<Playerhealth>().HP--;
                    isNoPick = true;
                }
                if ((push.collider.tag == "First") || (push.collider.tag == "Second") || (push.collider.tag == "Third") || (push.collider.tag == "Fourth"))
                {
                    audioSource.PlayOneShot(Beep);
                }
                if(push.collider.tag == "Reset")
                {
                    audioSource.PlayOneShot(Beep);
                    Debug.Log("reset");
                    CodeAnswer = null;
                    isCoding = true;
                    isNoPick = true;
                }

            }
            if(CodeAnswer.Length == 4)
            {
                isCoding = false;
            }

        }

    }
    public void Getnumbers(string i)
    {
            CodeAnswer += i;
    }
}
