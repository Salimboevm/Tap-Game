using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using CV.Data;
using System.IO;
using UnityEngine.Networking;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Video;

namespace CV {

    public class MainGame : MonoBehaviour {

        public static MainGame instance;
        public string ResultFolder => $"{Application.persistentDataPath}/";
        public Game game;

        Config config;
     
        void Awake() {
            instance = this;
            game = new Game();
            Application.targetFrameRate = 60;
        }

		void Start() {
            game.Initiallize();
		}

        public void AddResult(ItemsSave player) {
            ArrayList array = new ArrayList();
            if (PrefsManager.instance.prefs.HasKey("players"))
                array = PrefsManager.instance.prefs.Get<ArrayList>("players");

            PrefsManager.instance.prefs.Set("players", array);
            PrefsManager.instance.prefs.Save();
        }

        public void Save() {
            ArrayList array = new ArrayList();
            if (PrefsManager.instance.prefs.HasKey("players"))
                array = PrefsManager.instance.prefs.Get<ArrayList>("players");

            List<ItemsSave> list = new List<ItemsSave>();
            foreach (var item in array) {
                ItemsSave player = Helper.FromJson<ItemsSave>(item.ToString());
                list.Add(player);
            }
            string filePath = $"{ResultFolder}/all.csv";
            SaveToFile(list, filePath);

            //string filePath2 = $"{ResultFolder}/winners.csv";
            //SaveToFile(list.FindAll(f=>f.win).ToList(), filePath2);
        }

        public void SaveToFile(List<ItemsSave> list, string filePath) {
            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine("FirstPlayer,SecondPlayer,File_prefix,Date");
            foreach (var item in list) {
                string prefix = $"Form_{item.firstPlayer.Replace(" ", "").Replace("/", "_")}__";
                writer.WriteLine(item.firstPlayer + "," +
                                 item.secondPlayer + "," +
                                 prefix + "," +
                                 item.date);
            }

            writer.Flush();
            writer.Close();
        }
      
     }



}
