using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using CV.Data;

public class ItemsSave : MonoBehaviour
{
    public string firstPlayer;
    public string secondPlayer;

    public string date;
}
public class Game
{
    public void Initiallize()
    {
        itemsSave = new ItemsSave();
    }
    public ItemsSave itemsSave;
}
