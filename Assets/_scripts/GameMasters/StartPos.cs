using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPos : MonoBehaviour
{
    private GameObject[] players;

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
 
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
 
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
        players = GameObject.FindGameObjectsWithTag("Player");
        
        if(players.Length > 1)
            Destroy(players[1]);
    }
    

}
