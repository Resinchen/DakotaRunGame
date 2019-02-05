using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Data.importantScore++;
        Debug.Log(Data.importantScore + " objects");
        collectSound.Play();
        Destroy(gameObject);
        
    }
}
