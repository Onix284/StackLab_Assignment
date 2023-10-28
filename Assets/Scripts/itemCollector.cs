using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    private int charries = 0;
    [SerializeField] private Text charriesText;
    [SerializeField] private AudioSource collectSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cherry"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            charries++;
            charriesText.text = "Score: " + charries;
        }
    }

}
