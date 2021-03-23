using UnityEngine;
using TMPro;

public class TargetManager : MonoBehaviour
{
    public byte id;
    public CubeInstantiate cubeInstantiate;
    public string resType;
    //CubeMove cube;
    [HideInInspector]
    public bool filled = false;
    [HideInInspector]
    public GameObject res;
    public Vector3 force;
    [Header("Count")]
    public TextMeshPro countText;
    public int[] fills;
    [HideInInspector]
    public int fill = 2;
    public GameObject tick;
    public int stageId = 0;
    bool isFilled = false;
    public GameObject fluid;
    public int Fill
    {
        get => fill;
        set
        {
            float f = 1f * (fills[stageId] - value - 1) / fills[stageId];

            fill = value;
            float s = 1f * (fills[stageId] - value) / fills[stageId];

            StartCoroutine(MyTween.instance.Tween((v) =>
            { fluid.GetComponent<Renderer>().material.SetFloat("_Fill", v); },
            () =>
            {
                if (value == 0)
                    ActivateTick();
            }, f, s, 2*(s - f)));
            
            
            countText.text = fill.ToString("0");
        }
    }

    //private void Awake()
    //{
    //    countText.text = Fill.ToString();
    //}
    void Start()
    {
       // Fill = fills[0];
        GameManager.instance.players[id].SetTargets(this);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag(resType) || (isFilled && res == null))
        {
            other.attachedRigidbody.AddForce(force, ForceMode.Impulse);
            other.attachedRigidbody.AddExplosionForce(350, transform.position, 10, 0.5f);
        }
        else if (res == null)
        {
            filled = true;
            //cubeInstantiate.rightPlaced = true;
            res = other.gameObject;
            Fill--;
            
            if (Fill == 0)
            {
                if (Tutorial.instance.started)
                    Tutorial.instance.Next();
                isFilled = true;
                
                GameManager.instance.PlayerUpdate(id);
                
            }
            //ps.Play();
            GameManager.instance.Emptying(other.gameObject);
        }
    }
    public ParticleSystem ps;
    void ActivateTick()
    {
        tick.SetActive(true);
    }

    public void Restart()
    {
        Invoke("IR",2.3f);
        //Debug.Log("restart");
        
    }
    void IR()
    {
        Fill = fills[++stageId];
        tick.SetActive(false);
        isFilled = false;
    }

}



