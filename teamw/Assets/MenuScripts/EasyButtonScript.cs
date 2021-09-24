using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyButtonScript : MonoBehaviour
{
    //ボタンが押されたときに呼び出される関数
    public void Select()
    {
        Debug.Log("easy");
        //行われる操作　プレイシーン(easy)へ移動
        //←シーン結合後に消去　SceneManager.LoadScene("Game Scene easy");
    }
}
