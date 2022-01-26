using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAbillity : MonoBehaviour
{
    public GameObject Camera;
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
    bool isAbilty;

    void Start()
    {
        isAbilty = true;
        maxDistance = 30f;
        originalCrystalMat = WandCrystal.GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (isAbilty)
        { //Flag ability (raycast)
            origin = Camera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            if (Input.GetMouseButtonDown(1))
            {
                Debug.DrawRay(origin, Camera.transform.forward * maxDistance);
                if (Physics.Raycast(origin, Camera.transform.forward, out hit, maxDistance))
                {

                    if (hit.collider.tag == "color")
                    {
                        newMaterial = hit.transform.GetComponent<MeshRenderer>().material;
                        WandCrystal.GetComponent<MeshRenderer>().material = newMaterial;
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {

                if (Physics.Raycast(origin, Camera.transform.forward, out hit, maxDistance))
                {

                    if (hit.collider.tag == "colorObject")
                    {
                        hit.transform.GetComponent<MeshRenderer>().material = newMaterial;
                    }
                }
            }
            // check if solcved
            if (stripR.GetComponent<MeshRenderer>().material.color == red.color)
            {
                isRed = true;
            }
            else isRed = false;

            if (stripW.GetComponent<MeshRenderer>().material.color == white.color)
            {
                isWhite = true;
            }
            else isWhite = false;

            if (stripB.GetComponent<MeshRenderer>().material.color == blue.color)
            {
                isBlue = true;
            }
            else isRed = false;

            //if solved
            if (isWhite == true && isBlue == true && isRed == true)
            {
                Destroy(Door);
                WandCrystal.GetComponent<MeshRenderer>().material = originalCrystalMat;
                isAbilty = false;
            }


        }
    }
}