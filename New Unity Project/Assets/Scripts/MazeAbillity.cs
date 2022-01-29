using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeAbillity : MonoBehaviour
{
    //star position
    public Transform startPos;

    //Correct Portal
    public Transform room2Enter;
    public Transform room3Enter;
    public Transform room1Enter;

    bool isFar;

    public float range = 10;
    float shortestD = Mathf.Infinity;

    public GameObject gizmo2;
    public GameObject gizmo3;
    public GameObject gizmo1;

    void Start()
    {
       
    }

    void Update()
    {
        if(shortestD !> range)
        {
            isFar = true;
        }
        else
        {
            isFar = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "PortalWorng")
        {
            transform.position = startPos.transform.position;
        }
        if ((other.gameObject.tag == "PortalEnterW") && isFar == true)
        {
            transform.position = startPos.transform.position;
        }

        if (other.gameObject.tag == "PortalC1")
        {
            transform.position = room2Enter.transform.position;
        }

        if (other.gameObject.tag == "PortalC2")
        {
            transform.position = room3Enter.transform.position;
        }

        if (other.gameObject.tag == "PortalC3")
        {
            transform.position = room1Enter.transform.position;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gizmo2.transform.position, range);
        Gizmos.DrawWireSphere(gizmo3.transform.position, range);
        Gizmos.DrawWireSphere(gizmo1.transform.position, range);

    }
}
