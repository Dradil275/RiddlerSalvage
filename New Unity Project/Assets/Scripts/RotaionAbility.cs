using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaionAbility : MonoBehaviour
{
    //objects
    public GameObject Skeleton;
    public GameObject Protector;
    public GameObject Angel;
    public GameObject Girl;
    public GameObject Camera;
    public GameObject Door3;
    //Ray Cast
    Vector3 origin;
    RaycastHit hit;
    float maxDistance;
    bool isAbilty;
    public GameObject Psl;
    public GameObject Asl;
    float ProtectorY;
    //facing (Rotaion Alternative)
    int ProtectorFacing;
    int SkeletonFacing;
    int AngelFacing;
    //sound
    public AudioSource audioSource;
    public AudioClip TibettenGong;
    public AudioClip MoveStatueRight;
    public AudioClip MoveStatueLeft;
    public AudioClip LightSwitch;
    bool isWin;
    int Pswitch;
    int Aswitch;
    // Start is called before the first frame update
    void Start()
    {
        Pswitch = 2;
        isWin = false;
        maxDistance = 30;
        isAbilty = true;
        ProtectorFacing = 0;
        SkeletonFacing = 0;
        AngelFacing = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ProtectorY = Protector.transform.rotation.y;
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
                        audioSource.PlayOneShot(MoveStatueRight, 0.5f);
                        Debug.Log("hit protector");
                        Protector.transform.Rotate(0, 40, 0);
                        ProtectorFacing++;
                        Debug.Log(ProtectorFacing);

                    }
                    if (hit.collider.tag == "Angel")
                    {
                        audioSource.PlayOneShot(MoveStatueRight, 0.5f);
                        Debug.Log("Angel");
                        Angel.transform.Rotate(0, 30, 0);
                        AngelFacing++;
                    }
                    if (hit.collider.tag == "Skeleton")
                    {
                        audioSource.PlayOneShot(MoveStatueRight, 0.5f);
                        Skeleton.transform.Rotate(0, +30, 0);
                        SkeletonFacing++;
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
                        audioSource.PlayOneShot(MoveStatueLeft, 0.5f);
                        Protector.transform.Rotate(0, -40, 0);
                        ProtectorFacing--;
                    }
                    if (hit.collider.tag == "Angel")
                    {
                        audioSource.PlayOneShot(MoveStatueLeft, 0.5f);
                        Angel.transform.Rotate(0, -30, 0);
                        AngelFacing--;
                    }
                    if (hit.collider.tag == "Skeleton")
                    {
                        audioSource.PlayOneShot(MoveStatueLeft, 0.5f);
                        Skeleton.transform.Rotate(0, -30, 0);
                        SkeletonFacing--;
                    }
                }
            }
        }
        //facing restorer
        if (SkeletonFacing >= 12 || SkeletonFacing <= -12)
        {
            SkeletonFacing = 0;
        }
        if (ProtectorFacing >= 9 && ProtectorFacing <= -9)
        {
            ProtectorFacing = 0;
        }
        if (AngelFacing >= 12 || AngelFacing <= -12)
        {
            AngelFacing = 0;
        }

        // light conditions
        if (SkeletonFacing != 0)
        {
            
            if (Pswitch % 2 == 0)
            {
                audioSource.PlayOneShot(LightSwitch);
                Pswitch++;
            }
            Psl.SetActive(true);

        }
        if (SkeletonFacing == 0)  
        {
           
            if (Pswitch % 2 == 1)
            {
                audioSource.PlayOneShot(LightSwitch);
                Pswitch++;
            }
            Psl.SetActive(false);
        }
        if (ProtectorFacing == -4 || ProtectorFacing == 5 && SkeletonFacing != 0)
        {
            if (Aswitch % 2 == 0)
            {
                audioSource.PlayOneShot(LightSwitch);
                Aswitch++;
            }
                Asl.SetActive(true);

            }
            else
            {
                if (Aswitch % 2 == 1)
                {
                    audioSource.PlayOneShot(LightSwitch);
                    Aswitch++;
                }
                Asl.SetActive(false);
            }

        //win con
        if ((AngelFacing == -7 || AngelFacing == 5) && Asl.activeSelf == true)
        {
            if (isWin == false) audioSource.PlayOneShot(TibettenGong);
            isWin = true;
            Destroy(Door3, 0.27f);
        }

       

    }

}
 
