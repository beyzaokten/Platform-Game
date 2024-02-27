using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SceneSwitch : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject fireBalls;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject health;
    [SerializeField] GameObject door;


    private void Start()
    {
        ObjectsToSave();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            player.transform.position = new Vector3(-8, -3, 0);
        }
    }

    private void ObjectsToSave()
    {
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(fireBalls);
        DontDestroyOnLoad(camera);
        DontDestroyOnLoad(health);
        DontDestroyOnLoad(door);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
