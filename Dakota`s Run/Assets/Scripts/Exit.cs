using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    public string level;
    public int levelNum;
    public AudioSource completeSound;
    Character character;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (Data.importantScore == levelNum)
        {
            Debug.Log("LEVEL COMPLETE");
            if (!completeSound.isPlaying)
            {
                completeSound.Play();
            }
            Data.score += character.CurrentCountCoin;
            character.CurrentCountCoin = 0;
            Debug.Log(Data.score + "coin`s");

            // Если не набрано нужное количество монет, то выбрасывает на меню, позже измеить на панель с инфой
            if (level == "level6")
            {
                if (Data.score < 112)
                {
                    level = "fallfin";
                }
            }
            
            if (SceneManager.GetActiveScene().buildIndex == LevelManager.countUnlockedLevel)
            {
                LevelManager.countUnlockedLevel++;
            }
            StartCoroutine(nextLevel());
        }
    }


    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(completeSound.clip.length - 0.8f);
        Debug.Log("Coroutine is work");
        SceneManager.LoadScene(level);
    }
}
