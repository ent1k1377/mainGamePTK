using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebManager : MonoBehaviour
{

    static public IEnumerator ConnectDB(int id, int coin, int passge, int death)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("coin", coin);
        form.AddField("passage", passge);
        form.AddField("death", death);

        WWW www = new WWW("GameDB.local", form);
        yield return www;
    }

}
