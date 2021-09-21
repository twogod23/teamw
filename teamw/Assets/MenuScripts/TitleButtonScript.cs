using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonScript : MonoBehaviour
{
    //ボタンが押されたときに呼び出される関数
    public void Select()
    {
        //行われる操作 メインメニュー画面へ移動
        SceneManager.LoadScene("Mainmenu");
    }
}


//ボタンの設置
//1.UI⇒Buttonでボタンを設置
//2.位置・大きさを設定

//ボタンを機能させる
//1.スクリプトを書く
//2.スクリプトをボタンのオブジェクトに適用させる
//3.ボタンのInspector内のButtonのOnClick()のNoFunctionを「スクリプト名」⇒Select()に変更する

//ボタンに画像を入れる
//1.Projectから画像を選択
//2.InspectorのTextureTypeをSprite(2DandUI)に変更
//3.Hierarchyからボタンのオブジェクトを選択⇒InspectorのImageのSourceImageにProject内の画像をドラッグアンドドロップする
//4.必要に応じてボタンの子オブジェクトのTextの文字を消去する

//動画の挿入方法
//1.UI⇒RawImageを選択
//2.ProjectからRenderTextureを作成
//3.RawImageのInspectorにVideoPlayerのコンポーネントを追加
//4.Inspector内の、RawImageのTextureとVideoPlayerのTargetTextureに、作成したRenderTextureをドラッグアンドドロップする

//Canvas内のオブジェクトは上が奥、下が手前に表示される

//シーン遷移を設定する際は、File⇒BuildSettingにシーンを登録することを忘れない