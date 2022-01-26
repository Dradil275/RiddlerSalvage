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
                        hit.transform.Rotate(new Vector3(0, +94, 0));
                    }
                    if(hit.collider.tag == "Angel")
                    {
                        Debug.Log("Angel");
                        hit.transform.Rotate(new Vector3(0, +105, 0));
                    }
                    if(hit.collider.tag == "Skeleton")
                    {
                        hit.transform.Rotate(new Vector3(0, +90, 0));
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
                        hit.transform.Rotate(new Vector3(0, -94, 0));
                    }
                    if (hit.collider.tag == "Angel")
                    {
                        Debug.Log("Angel");
                        hit.transform.Rotate(new Vector3(0, -105, 0));
                    }
                    if (hit.collider.tag == "Skeleton")
                    {
                        hit.transform.Rotate(new Vector3(0, -90, 0));
                    }
                }
            }
        }

    }
}
