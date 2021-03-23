using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataOfPlayer
{
    public string player1;
    public string player2;

    public DataOfPlayer(SavePlayerData game)
    {
        player1 = game.player1.text;
        player2 = game.player2.text;
    }
}
