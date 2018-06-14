using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{

    public GameObject player;
    

    [System.Serializable]
    public class Status
    {

        public float x;
        public float y;
        public int HP;
        public Scene scene;
    }

    public void Save()
    {
        var status = new Status();
        status.x = player.transform.position.x;
        status.y = player.transform.position.y;
        status.HP = player.GetComponent<Controller_Players>().HP;

        if (!Directory.Exists(Application.dataPath + "/saves"))
            Directory.CreateDirectory(Application.dataPath + "/saves");

        FileStream fs = new FileStream(Application.dataPath + "/saves/saves/sv", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        fs.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/saves/saves/sv"))
        {
            FileStream fs = new FileStream(Application.dataPath + "/saves/saves/sv", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                Status stat = (Status)formatter.Deserialize(fs);
                player.transform.position = new Vector2(stat.x, stat.y);
                player.GetComponent<Controller_Players>().HP = stat.HP;
                player.GetComponent<Controller_Players>().CurrentScene = stat.scene;
            }
            catch(System.Exception e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
