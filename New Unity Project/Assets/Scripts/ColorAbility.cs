using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorAbility : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Health;
    Vector3 origin;
    RaycastHit hit;
    float maxDistance;
    Material newMaterial;
    public Material Grey;
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
    //sound 
    public AudioClip Natarz6;
    public AudioClip Natarz7;
    public AudioClip TwinBells;
    public AudioSource audioSource;

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
                        audioSource.PlayOneShot(Natarz6, 0.7f);
                        Invoke("GetMaterial", 0.23f);
               
                       
                    }
             
                    
                }
            }
            if (Input.GetMouseButtonDown(0))
            {

                if (Physics.Raycast(origin, Camera.transform.forward, out hit, maxDistance))
                {

                    if (hit.collider.tag == "colorObject")
                    {
                        audioSource.PlayOneShot(Natarz7,0.7f);
                        Invoke("SetMaterial", 0.23f);
                    }
                    if (hit.collider.tag == "Button")
                   {

                    if (isGreen == true && isYellow == true && isRed == true && isSolved == false)
                    {
                        audioSource.PlayOneShot(TwinBells);
                        Destroy(Door);
                        WandCrystal.GetComponent<MeshRenderer>().material = originalCrystalMat;
                        newMaterial = Grey;
                        isSolved = true;
                    }
                    else Health.GetComponent<Playerhealth>().TakeDamage();
                    
                }
                if (hit.collider.tag == "FinalButton")
                    {
                    SceneManager.LoadScene("GameOver");
                    
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

      
 /*       if (isGreen == true && isYellow == true && isRed == true && isSolved == false)
        {
            audioSource.PlayOneShot(TwinBells);
            Destroy(Door);
            WandCrystal.GetComponent<MeshRenderer>().material = originalCrystalMat;
            isSolved = true;
        }
       */
     
    }
    //methods
    public void GetMaterial()
    {
        newMaterial = hit.transform.GetComponent<MeshRenderer>().material;
        WandCrystal.GetComponent<MeshRenderer>().material = newMaterial;
    }
    public void SetMaterial()
    {
        hit.transform.GetComponent<MeshRenderer>().material = newMaterial;
    }
}
