using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;
    public bool started;
    public Stage[] stages;
    [HideInInspector] public Vector3 tttt;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }
    public void StartTutorial()
    {
        Next();
        started = true;
        Train.instance.speed = 0;
    }
    public void StopTutorial()
    {
        started = false;
        Train.instance.speed = Train.instance.minSpeed;
    }
    int stageid = 0;
    public void Next()
    {
        Invoke("NextI", 1);
    }
    void NextI()
    {
        if (stageid != 0)
            foreach (GameObject item in stages[stageid - 1].actives)
            {
                if (item != null)
                    item.SetActive(false);
            }
        if (stageid >= 4) return;

        foreach (GameObject item in stages[stageid].actives)
        {

            item.SetActive(true);
        }
        foreach (Collider item in stages[stageid].resC)
        {
            Origin or = item.gameObject.GetComponent<Origin>();
            if (or != null)
                or.Set();
            item.enabled = true;
        }
        stageid++;
    }
    public void OnTriggerExit(Collider other)
    {
        if (Tutorial.instance.started)
        {
            Vector3 e = other.gameObject.GetComponent<Origin>().or;
            Destroy(other.gameObject);
            GameObject go = Instantiate(other.gameObject);
            go.GetComponent<Rigidbody>().isKinematic = true;
            go.transform.position = e;
            go.transform.localScale = Vector3.one;
            go.GetComponentInChildren<Animator>().enabled = true;
            print("exit");
        }
    }
}
[System.Serializable]
public class Stage
{
    public GameObject[] actives;
    public Collider[] resC;
}