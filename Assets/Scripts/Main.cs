using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject loseTxt;
    [SerializeField] private GameObject winTxt;

    void Start()
    {
        Time.timeScale = 1;
    }


    void Update()
    {
        
    }

    public void Lose()
    {
        loseTxt.SetActive(true);
        Time.timeScale = 0;

    }

    public void Win()
    {
        winTxt.SetActive(true);
        Time.timeScale = 0;

    }


    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
