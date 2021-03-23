using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SavePlayerData : MonoBehaviour
{
    public Text player1, player2;
    public TextMeshPro player1get, player2get;
    public GameObject game, main;

    public void ButtonStart()
    {
        PlayerPrefs.SetString("player1text", player1.text);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("player2text", player2.text);
        PlayerPrefs.Save();
        SaveSystem.Player(this);
    }
    public void ButtonLoad()
    {
        player1get.text = PlayerPrefs.GetString("player1text", "Player One");
        player2get.text = PlayerPrefs.GetString("player2text", "Player Two");
    }
    
    public void Starter(int id)
    {
        Time.timeScale = 1;
        if(id == 0)
        {   game.SetActive(true);
            main.SetActive(false);

            //Train.instance.minSpeed = 1.5f;
            //Train.instance.maxSpeed = 4.5f;
            CubeInstantiate.instance.maxNumber = 16;

        }
        if (id == 1)
        {
            
            game.SetActive(false);
            main.SetActive(true);
            //Train.instance.minSpeed = 2.5f;
            //Train.instance.maxSpeed = 5.5f;
            CubeInstantiate.instance.maxNumber = 13;
        }

    }
    public void Home()
    {
        //CubeInstantiate.currentValueOfCubes = 0;    
        SceneManager.LoadScene(0);
    }
}
