using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float scoreUpdateWaitTime;
    public GameObject[] bottle;

    Animator currentBottleAC;

    public bool isWinned = false;
    private void Awake()
    {
        instance = this;
        //players = new Player[] { new Player(), new Player() };
        new MyTween();
    }

    //void WinnerSelecter()
    //{
    //    
    //    
    //    //if (players[id].score >= 5)
    //    //{
    //    //    string tag = (id == 0 ? "player1text" : "player2text");
    //    //    UIManager.instance.winnerName.text = PlayerPrefs.GetString(tag);
    //    //    UIManager.instance.win.SetActive(true);
    //    //    Time.timeScale = 0;
    //    //}
    //}
    public float speed;
    void Invoker()
    {
        UIManager.instance.win.gameObject.SetActive(true);
        StartCoroutine(MyTween.instance.Tween((v) => { UIManager.instance.win.alpha = v; },
                                              () => { UIManager.instance.win.interactable = true; Time.timeScale = 0; } , 0, 1, speed));
        
    }

    public void PlayerUpdate(byte id)
    {
        Player player = players[id].UpdatePlayerScore();
       

        if (player != null)
        {
            StartCoroutine(RefreshScore(player));
        }

        if (players[id].Score == 3)
        {
            isWinned = true;
            string tag = id == 1 ? "player2text" : "player1text";
            //Debug.Log("Player 2 Win");
            //UIManager.instance.winnerName.text = PlayerPrefs.GetString(tag, "Player");
            //player.StartBottleAnim();
            Invoke("Invoker", 1.5f);

        }

    }
    IEnumerator RefreshScore(Player p)
    {
        yield return new WaitForSeconds(scoreUpdateWaitTime);
        p.CreateButtle();
    }
    public Player[] players;

    public void Emptying(GameObject res)
    {
        res.GetComponent<Renderer>().enabled = false;
        if (res.GetComponentInChildren<SpriteRenderer>())
        {
            res.GetComponentInChildren<SpriteRenderer>().enabled = false;
            print("res.GetComponentInChildren<SpriteRenderer>().enabled = false;");
        }
        Destroy(res, 0.5f);
        //res.GetComponent<Rigidbody>().isKinematic = true;
        
        //res.GetComponent<ParticleSystem>().Play();
        //Destroy(res);
    }
}
