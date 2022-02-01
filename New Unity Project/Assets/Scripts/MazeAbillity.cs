using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeAbillity : MonoBehaviour
{
    //start position
    public Transform startPos;

    //Correct Portal
    public Transform room2Enter;
    public Transform room3Enter;
    public Transform room1Enter;
    public Transform closeToEnd;

    // when go back to enter portal - go back to startPos
    bool isInside;

    //sound
    public AudioSource audioSource;
    public AudioClip Teleport;
    public AudioClip TwinBells;
    public AudioClip bars;
    public AudioClip wandGone;

    //other
    public GameObject doorC;
    Vector3 posDoor;
    public GameObject wand;
    public GameObject doorEnd;

    void Start()
    {
        isInside = true;
        posDoor = new Vector3(0, 3, -151.7f);
    }

    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "PortalWorng")
        {
            audioSource.PlayOneShot(Teleport, 0.7f);
            transform.position = startPos.transform.position;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 172, transform.rotation.z);
        }
        if (other.gameObject.tag == "GoBack")
        {
            isInside = false;
        }
        if ((other.gameObject.tag == "PortalEnterW") && isInside == false)
        {
            isInside = true;
            audioSource.PlayOneShot(Teleport, 0.7f);
            transform.position = startPos.transform.position;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 172, transform.rotation.z);
        }
        if (other.gameObject.tag == "PortalC1")
        {
            audioSource.PlayOneShot(Teleport, 0.7f);
            transform.position = room2Enter.transform.position;
            isInside = true;
        }

        if (other.gameObject.tag == "PortalC2")
        {
            audioSource.PlayOneShot(Teleport, 0.7f);
            transform.position = room3Enter.transform.position;
            isInside = true;
        }

        if (other.gameObject.tag == "PortalC3")
        {
            audioSource.PlayOneShot(Teleport, 0.7f);
            transform.position = room1Enter.transform.position;
            isInside = true;
            Destroy(doorEnd);
            audioSource.PlayOneShot(TwinBells);

        }
        if (other.gameObject.tag == "DoorClose")
        {
            Instantiate(doorC, posDoor, doorC.transform.rotation);
            Destroy(other.gameObject);
            audioSource.PlayOneShot(bars);
            audioSource.PlayOneShot(wandGone);
            Destroy(wand);
        }
        if (other.gameObject.tag == "CloseToEnd")
        {
            audioSource.PlayOneShot(Teleport, 0.7f);
            transform.position = closeToEnd.transform.position;
            isInside = true;
        }
        

    }
}
