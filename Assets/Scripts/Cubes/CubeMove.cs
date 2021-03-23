using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CubeMove : MonoBehaviour
{
    float posX, posY;

    RaycastHit hit;

    Ray ray;
    Camera cam;
    public Transform tableLevel;
    float stwpdY;
    void Awake()
    {
        cam = Camera.main;
        //touchInfoL = new TouchInfo[20];
    }
    void Start()
    {
        stwpdY = cam.transform.position.y - tableLevel.position.y;
    }
    [HideInInspector]
    public Touch touch;
    Vector3 velocity;
    public float smoothTime = 0.5f;
    [Header("Explosion")]
    public float power, radius;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                touch = Input.touches[i];
                int id = touch.fingerId;
                ray = cam.ScreenPointToRay(touch.position);
                //print("finger id : "+touch.fingerId);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        {
                            TouchInfo info = new TouchInfo(id);
                            if (Physics.Raycast(ray,out hit))
                            {
                                if (!hit.transform.CompareTag("Untagged"))
                                {
                                    Tutorial.instance.tttt = hit.transform.gameObject.transform.position;
                                    info.Set(id, hit.transform.tag, TouchState.selected, hit.transform.gameObject);
                                    //info.rb.useGravity = false;
                                    info.rb.isKinematic = true;
                                }
                            }
                            touchInfoL.Add(id, info);
                            //Add(info);
                        }
                        break;
                    case TouchPhase.Moved:
                        {
                            if (touchInfoL[id].state != TouchState.selected)
                                break;
                            Physics.Raycast(ray, out hit);
                            TouchInfo info = touchInfoL[id];
                            Vector3 current;
                            try
                            {
                                current = info.obj.transform.position;
                            }
                            catch (Exception) { return; }
                            //Vector3 newpos = current - new Vector3(touch.deltaPosition.x,0, touch.deltaPosition.y);
                            //Vector3 newpos = new Vector3(hit.point.x, 6, hit.point.z);
                            Vector3 newpos = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, stwpdY)) + Vector3.up * 2;
                            //info.rb.MovePosition(Vector3.SmoothDamp(current, newpos, ref velocity, smoothTime));
                            info.obj.transform.position = Vector3.SmoothDamp(current, newpos, ref velocity, smoothTime);
                            info.obj.transform.localScale = new Vector3(2f,2f,2f);
                            info.obj.transform.SetParent(null);
                            //info.obj.transform.Rotate(1f,1f,1f);
                        }
                        break;
                    case TouchPhase.Ended:
                        {
                            TouchInfo info = touchInfoL[id];
                            if (!Tutorial.instance.started)
                            {
                                
                                if (info.rb != null)
                                {
                                    info.rb.isKinematic = false;
                                    
                                }
                            }
                            if (info.rb != null)
                                info.rb.useGravity = true;
                        }
                        break;
                }
                
            }

            for (int i = 0; i < Input.touches.Length; i++)
            {
                int id = id = Input.touches[i].fingerId;
                if (Input.touches[i].phase == TouchPhase.Ended)
                {
                    //print("touchInfoL.Count 1 : " + touchInfoL.Count);
                    if (touchInfoL[id].rb != null && !Tutorial.instance.started)
                        touchInfoL[id].rb.isKinematic = false;
                    
                        touchInfoL.Remove(touchInfoL[id].id);
                    //print("touchInfoL.Count 2 : " + touchInfoL.Count);
                }
            }
        }
    }
    Dictionary<int,TouchInfo> touchInfoL = new Dictionary<int,TouchInfo>();
    //TouchInfo[] touchInfoL;

    void Remove(TouchInfo t,int count)
    {
        for (int i = t.id; i < count - t.id; i++)
            touchInfoL[i] = touchInfoL[i + 1];
    }
    void Add(TouchInfo t)
    {
        print("add t od ; "+t.id);
        touchInfoL[t.id] = t;
    }
}
class TouchInfo
{
    public int id;
    public string tag;
    public TouchState state = TouchState.notselected;

    public GameObject obj;
    public Rigidbody rb;
    public TouchInfo(int id)
    {
        this.id = id;
    }

    public void Set(int id,string tag,TouchState state,GameObject obj)
    {
        this.id = id;
        this.tag = tag;
        this.state = state;
        this.obj = obj;
        rb = obj.GetComponent<Rigidbody>();
    }

}
enum TouchState
{
    selected,
    notselected
}