using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyButtonScript : MonoBehaviour
{
    //ボタンが押されたときに呼び出される関数
    public void Select()
    {
        Debug.Log("easy");
        //行われる操作　プレイシーン(easy)へ移動
        SceneManager.LoadScene("Game Scene easy");
    }
}
