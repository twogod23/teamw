using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAnnouncementScript : MonoBehaviour
{
    
    //時間を表す言葉を指定
    private float announcementtime = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //スタートのテキストの表示
        StartAnnouncementText.SetActive(true);
    }

    public GameObject StartAnnouncementText;

    // Update is called once per frame
    void Update()
    {
        //フレームによる時間を追加
        announcementtime += Time.deltaTime;

        //時間経過後、テキストを隠す
        if(announcementtime > 1.5f)
        {
            StartAnnouncementText.SetActive(false);
        }
    }
}
