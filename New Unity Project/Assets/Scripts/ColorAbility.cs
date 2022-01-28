using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAbility : MonoBehaviour
{
    public GameObject Camera;
    Vector3 origin;
    RaycastHit hit;
    float maxDistance;
    Material newMaterial;
    public GameObject Door;
    public Material Green;
    public Material Yellow;
    public Material Red;
    Material originalCrystalMat;
    public GameObject SphereG;
    public GameObject SphereY;
    public GameObject SphereR;
    public GameObject WandCrystal;
    bool isGreen;
    bool isYellow;
    bool isRed;
    bool isSolved;

    //Health aid
    public GameObject life;
    private PlayerEngine int_life;

    void Start()
    {
        isSolved = false;
        maxDistance = 30f;
        originalCrystalMat = WandCrystal.GetComponent<MeshRenderer>().material;

        //Health aid
        int_life = life.GetComponent<PlayerEngine>();
        int_life.life = 5;
    }


    void Update()
    {
      
         //color ability (raycast)
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
        if (SphereG.GetComponent<MeshRenderer>().material.color == Green.color)
        {
            isGreen = true;
            
        }
        else
        {
            isGreen = false;
        }
        if (SphereY.GetComponent<MeshRenderer>().material.color == Yellow.color)
        {
            isYellow = true;
            
        }
        else
        {
            isYellow = false;
        }
        if (SphereR.GetComponent<MeshRenderer>().material.color == Red.color)
        {
            isRed = true;
           
        }
        else
        {
            isRed = false;
        }
        //if solved
        if (isGreen == true && isYellow == true && isRed == true && isSolved == false)
        {
            Destroy(Door);
            WandCrystal.GetComponent<MeshRenderer>().material = originalCrystalMat;
            isSolved = true;
        }
    }
}
