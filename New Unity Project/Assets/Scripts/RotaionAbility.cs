using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaionAbility : MonoBehaviour
{
    public GameObject Skeleton;
    public GameObject Protector;
    public GameObject Angel;
    public GameObject Girl;
    public GameObject Camera;
    Vector3 origin;
    RaycastHit hit;
    float maxDistance;
    bool isAbilty;
    public GameObject Psl;
    public GameObject Asl;
    bool isProtectorLight;
    bool isAngelLight;
    // Start is called before the first frame update
    void Start()
    {
        maxDistance = 30;
        isAbilty = true;

    }

    // Update is called once per frame
    void Update()
    {
        origin = Camera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        if (isAbilty)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.DrawRay(origin, Camera.transform.forward * maxDistance);
                if (Physics.Raycast(origin, Camera.transform.forward, out hit, maxDistance))
                {

                    if (hit.collider.tag == "Protector")
                    {
                        Debug.Log("hit protector");

                        Protector.transform.Rotate(0,40, 0);


                    }
                    if (hit.collider.tag == "Angel")
                    {
                        Debug.Log("Angel");
                        Angel.transform.Rotate(0, 30, 0);
                    }
                    if (hit.collider.tag == "Skeleton")
                    {
                        Skeleton.transform.Rotate(0, +30, 0);
                    }

                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.DrawRay(origin, Camera.transform.forward * maxDistance);
                if (Physics.Raycast(origin, Camera.transform.forward, out hit, maxDistance))
                {

                    if (hit.collider.tag == "Protector")
                    {
                        Debug.Log("hit protector");
                        Protector.transform.Rotate(0, -40, 0);
                    }
                    if (hit.collider.tag == "Angel")
                    {
                        Debug.Log("Angel");
                        Angel.transform.Rotate(0, -30, 0);
                    }
                    if (hit.collider.tag == "Skeleton")
                    {
                        Skeleton.transform.Rotate(0, -30, 0);
                    }
                }
            }
        }

        // light conditions
        if (Skeleton.transform.rotation.y != 0 && isProtectorLight == false)
        {

            Psl.SetActive(true);
           
        }
        if(Skeleton.transform.rotation.y == 0)
        {
            Psl.SetActive(false);
        }
       
      /*  if()
        {
            Debug.Log("ASL");
            Asl.SetActive(true);
            isProtectorLight = true;
        }*/
        if(isProtectorLight == true)
        {
            Psl.SetActive(false);
        }

    }
}
 
