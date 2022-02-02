using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerhealth : MonoBehaviour
{
    [SerializeField] private float playerHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthImage;
    [SerializeField] private int Damage;
    [SerializeField] private int HalfDamage;
    public int HP;
    //sound
    public AudioSource audioSource;
    public AudioClip Hurt;

    private void Start()
    {
        HP = 5;
    }
    public void TakeDamage()
    {
        playerHealth -= Damage;
        UpdateHealth();
       
    }

    public void UpdateHealth()
    {
        healthImage.fillAmount = playerHealth / maxHealth;
        audioSource.PlayOneShot(Hurt, 0.8f);
    }
    public void TakeHalfDamage()
    {
        playerHealth -= HalfDamage;
        UpdateHealth();
    }
    private void Update()
    {
        if(HP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
