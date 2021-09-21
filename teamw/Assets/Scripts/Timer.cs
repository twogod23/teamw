using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{   
    public float totalTime = 120; //制限時間
    GameObject timeText;
    public Text time_text;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("Time");
        time_text = timeText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //トータルタイム減算
        if(totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            time_text.text = "制限時間  " + totalTime.ToString("f2");
        } else{
            totalTime = 0;
            time_text.text = "制限時間  0";
            SceneManager.LoadScene("sub2");
        }
    }
}
