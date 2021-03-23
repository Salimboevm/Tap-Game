    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//namespace CV.Data {
public class PrefsManager : MonoBehaviour
{

    [System.NonSerialized] public Prefs.Data prefs;

    public static PrefsManager instance;
    public static PrefsManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        prefs = Prefs.Load("data_prefs");

    }

    public void Save()
    {
        if (prefs.dirty)
        {
            prefs.Save();
        }
        SceneManager.LoadScene(1);
    }

    void OnDisable()
    {
        Save();
        Prefs.Save();
    }

    void OnApplicationQuit()
    {
        Save();
        Prefs.Save();
    }

    void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            Save();
            Prefs.Save();
        }
    }
}
//}
