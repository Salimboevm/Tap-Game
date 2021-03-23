using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace CV {

    public class PlayersView : MonoBehaviour {

        public InputField inputFirstPlayer, inputSecondPlayer;
        bool clicked = false;

        public void Show(bool clear = false) {
            clicked = false;

            if (clear) {
                MainGame.instance.game.itemsSave = new ItemsSave();
                ClearData();
            }
        }

        public void OnClickNext() {
            if (clicked)
                return;
            clicked = true;
            ItemsSave player = MainGame.instance.game.itemsSave;
            player.firstPlayer = inputFirstPlayer.text;
            player.secondPlayer = inputSecondPlayer.text;

        }

        void ClearData() {
            inputFirstPlayer.text = "";
            inputSecondPlayer.text = "";
        }
    }
}