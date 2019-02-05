using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountCoins : MonoBehaviour {

    Character character;

    [SerializeField]
    int maxCountOfLevel;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
    }

    void Update () {
        GetComponent<Text>().text = character.CurrentCountCoin.ToString() + " / " + maxCountOfLevel;
    }
}
