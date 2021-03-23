using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInstantiate : MonoBehaviour
{

    /*public GameObject cube;
    public Transform parent;
    public GameObject[] rightCubesObjects;

    //TargetManager target;
    public int maxValueOfCubes = 400;
    [HideInInspector]
    public static int currentValueOfCubes;

    float time = 0;
    public int rightCubes = 1;
    [HideInInspector]
    public bool rightPlaced = false;
    private void Start()
    {
        InvokeRepeating("CubeInstantiater", 1f, 0.1f);
    }

    private void CubeInstantiater()
    {
        time += 1 * Time.fixedDeltaTime;
        if (currentValueOfCubes <= maxValueOfCubes)
        {
            if (time > 10 || rightPlaced == true)
            {
                for (int i = 0; i < rightCubes; i++)
                {
                    //Instantiate(rightCubesObjects[MyRandom(0, rightCubesObjects.Length - 1)],new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)), Quaternion.identity, parent);
                    Instantiate(rightCubesObjects[MyRandom(0, rightCubesObjects.Length - 1)], Random.onUnitSphere+ parent.position, Quaternion.identity, parent);
                }
                currentValueOfCubes += 20;
                time = 0;
            }
            rightPlaced = false;
        }
        else
        {
            return;
        }
    }
    int randomSeed = 0;

    float MyRandom(float min, float max)
    {
        randomSeed+=5;
        UnityEngine.Random.InitState(randomSeed += (int)System.DateTime.Now.Millisecond);

        return Random.Range(min, max);
    }
    int MyRandom(int min, int max)
    {
        randomSeed+=5;
        UnityEngine.Random.InitState(randomSeed += (int)System.DateTime.Now.Millisecond);

        return Random.Range(min, max);
    }*/

    public static CubeInstantiate instance;
    public GameObject train;
    public Transform parent;

    public short maxNumber;
    short currentValue = 1;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //InvokeRepeating("Instantiate", 2.4f, 10.8f);
        waitTime = 10.8f;


    }
    [HideInInspector] public float waitTime;
    //IEnumerator Instantiate()
    //{
    //    yield return new WaitForSeconds(2.4f);
    //    while (true)
    //    {
    //        GameObject g = Instantiate(train, new Vector3(7.2f, 2.4f, 33f), Quaternion.Euler(90, 180, 90));
    //        g.transform.localScale = new Vector3(2.3f, 2.3f, 1f);
    //        g.transform.SetParent(parent, worldPositionStays: true);
    //        yield return new WaitForSeconds(waitTime);
    //    }
    //}


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("vagon"))
            if (currentValue <= maxNumber || !ResType.isAllResCreated)
            {
                GameObject g = Instantiate(train, new Vector3(7.2f, 2.4f, 33f), Quaternion.Euler(90, 180, 90));
                g.transform.localScale = new Vector3(2.3f, 2.3f, 1f);
                g.transform.SetParent(parent, worldPositionStays: true);
                currentValue++;
            }
            else if (ResType.isAllResCreated && !GameManager.instance.isWinned)
            {
                UIManager.instance.lose.gameObject.SetActive(true);
                StartCoroutine(MyTween.instance.Tween((v) => { UIManager.instance.lose.alpha = v; },
                                       () => { UIManager.instance.lose.interactable = true; }, 0, 1, 1));
            }
    }
}
