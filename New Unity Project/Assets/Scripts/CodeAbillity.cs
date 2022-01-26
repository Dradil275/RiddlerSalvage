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


    public GameObject door;


    void Start()
    {
        maxDistance = 10f;

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
                    push.transform.GetComponent<MeshRenderer>().material.color = Color.green;
                    isNoPick = false;
                    isCorrect1 = true;
                }
                else
                    push.transform.GetComponent<MeshRenderer>().material.color = Color.red;



                //second bottun
                if ((push.collider.tag == "Second") && isCorrect1 == true)
                {
                    push.transform.GetComponent<MeshRenderer>().material.color = Color.green;
                    isCorrect2 = true;
                }

                //third bottun
                if ((push.collider.tag == "Third") && isCorrect2 == true)
                {
                    push.transform.GetComponent<MeshRenderer>().material.color = Color.green;
                    isCorrect3 = true;
                }

                //fourth bottun
                if ((push.collider.tag == "Fourth") && isCorrect3 == true)
                {
                    push.transform.GetComponent<MeshRenderer>().material.color = Color.green;
                    isCorrect4 = true;

                }


                if (isCorrect1 && isCorrect2 && isCorrect3 && isCorrect4 == true)
                {
                    Destroy(door);
                }
            }

        }
    }
}
