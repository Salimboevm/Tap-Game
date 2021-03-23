using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    [HideInInspector]public List<TargetManager> targets;

    [HideInInspector]
    private int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreT.text = score.ToString("0");
        }
    }
    [HideInInspector]
    public byte rightPlacedCubes = 0;
    public TextMeshPro scoreT;
    void Awake()
    {
        targets = new List<TargetManager>();
    }
    private void Start()
    {
        CreateButtle();
    }
    public Player UpdatePlayerScore()
    {
        if (rightPlacedCubes == 3)
        {
            if(score == 0)
                Tutorial.instance.StopTutorial();
            Score += 1;print("l");
            StartBottleAnim();
            Train.instance.UpdateSpeed();
            rightPlacedCubes = 0;
            //Debug.Log("3");
            foreach (TargetManager t in targets)
            {
                //Debug.Log("3 foreach");
                //GameManager.instance.Emptying(t.res);
                if (t.fills.Length == Score)
                    return null;
                t.Restart();
            }
            return this;
        }
        else
        {
            rightPlacedCubes += 1;
            return null;
        }
    }
    Animator animator;
    
    public void CreateButtle()
    {
        GameObject go = Instantiate(GameManager.instance.bottle[Score], transform);
        animator = go.GetComponent<Animator>();
        print(animator.name);
    }
    public void StartBottleAnim()
    {
        animator.SetBool("mover", true);
    }
    public void SetTargets(TargetManager target)
    {
        targets.Add(target);
    }
}