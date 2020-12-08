using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebManager : MonoBehaviour
{

    static public IEnumerator ConnectDB(int id, int coin, int passge, int death, int timePassage)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("coin", coin);
        form.AddField("passage", passge);
        form.AddField("death", death);
        form.AddField("timePassage", timePassage);

        WWW www = new WWW("GameDB.local", form);
        yield return www;
    }

    static public IEnumerator SelectLevelCoins(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);

        WWW www = new WWW("GameDB.local/selectLevelCoins.php", form);
        yield return www.text;
        Level.text = www.text;
        print(Level.text);
        
    }

}
