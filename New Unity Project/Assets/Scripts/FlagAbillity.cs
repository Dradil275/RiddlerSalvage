using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAbillity : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Health;
    Vector3 origin;
    RaycastHit hit;
    float maxDistance;
    Material newMaterial;
    public GameObject Door;
    public Material white;
    public Material blue;
    public Material red;
    Material originalCrystalMat;
    public GameObject stripR;
    public GameObject stripW;
    public GameObject stripB;
    public GameObject WandCrystal;
    bool isBlue;
    bool isWhite;
    bool isRed;

    //color abillity
    public GameObject isAbillity;
    private ColorAbility ca;

    //Health aid
    public GameObject life;
    private PlayerEngine int_life;

    //sound
    public AudioSource audioSource;
    public AudioClip Victory;
    bool isWin;

    void Start()
    {
        isWin = false;
        maxDistance = 30f;
        originalCrystalMat = WandCrystal.GetComponent<MeshRenderer>().material;

        //Health aid
        int_life = life.GetComponent<PlayerEngine>();
        int_life.life = 5;

    }

    void Update()
    {


        // check if solcved
        if (stripR.GetComponent<MeshRenderer>().material.color == red.color)
        {
            isRed = true;
        }
        else
        {
            isRed = false;
        }

        if (stripW.GetComponent<MeshRenderer>().material.color == white.color)
        {
            isWhite = true;
        }
        else
        {
            isWhite = false;
        }
        if (stripB.GetComponent<MeshRenderer>().material.color == blue.color)
        {
            isBlue = true;
        }
        else
        {
            isBlue = false;
        }
        //if solved
        if (Input.GetMouseButtonDown(0))
        {
            origin = Camera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(origin, Camera.transform.forward, out hit, maxDistance))
            {
                if (hit.collider.tag == "Button4")
                {
                    if (isWhite == true && isBlue == true && isRed == true)
                    {
                        if (isWin == false) audioSource.PlayOneShot(Victory);
                        isWin = true;
                        Destroy(Door);
                        WandCrystal.GetComponent<MeshRenderer>().material = originalCrystalMat;

                    }
                    else Health.GetComponent<Playerhealth>().TakeDamage();
                }
               
        
            }









        }
    }
}