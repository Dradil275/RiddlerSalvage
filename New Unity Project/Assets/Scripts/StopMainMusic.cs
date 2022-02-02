using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMainMusic : MonoBehaviour
{
    GameObject mainmusic;
    // Start is called before the first frame update
    void Start()
    {
       mainmusic = GameObject.Find("BackRound MUSIC");
    }

    // Update is called once per frame
    void Update()
    {
       mainmusic.GetComponent<MENUmusic>().StopMusic();
    }
}
