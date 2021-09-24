using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardButtonScript : MonoBehaviour
{
    //ボタンが押されたときに呼び出される関数
    public void Select()
    {
        Debug.Log("hard");
        //行われる操作 ゲームシーン(hard)へ移動
        //←シーン結合後に消去　SceneManager.LoadScene("Game Scene hard");
    }
}
