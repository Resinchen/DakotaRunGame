using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    public AudioSource collectSound;

    private Character character;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        character.CurrentCountCoin++;
        collectSound.Play();
        Destroy(gameObject);

    }
}
