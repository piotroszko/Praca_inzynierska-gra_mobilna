using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
        
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1; //na +2 jezli do testowania ostatniego bossa

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            GameObject.FindWithTag("PlayerManager").GetComponent<CharacterValues>().replayTimes ++;
            nextSceneIndex = 1;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}