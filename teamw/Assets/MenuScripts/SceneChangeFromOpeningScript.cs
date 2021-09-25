using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeFromOpeningScript : MonoBehaviour
{
     //シーンが変わる時間(changetime)を指定
    private float changetime = 85.0F;

    private float starttime;

    // Start is called before the first frame update
    void Start()
    {
        //動画が再生された時間(starttime)を計測
        starttime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        //指定した時間が過ぎたら、シーンを遷移
        if(Time.realtimeSinceStartup - starttime > changetime)
        {
            SceneManager.LoadScene("Mainmenu");
        }
    }
}