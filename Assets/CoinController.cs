using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour
{
    //unityChanを追加
    private GameObject unityChan;

    // Use this for initialization
    void Start()
    {
        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);

        //シーン中のunityChanオブジェクトを取得
        this.unityChan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //回転
        this.transform.Rotate(0, 3, 0);

        //オブジェクトが画面外に出た場合
        if (10 < this.unityChan.transform.position.z - this.transform.position.z)
        {
            //オブジェクトを破棄
            Destroy(this.gameObject);
        }
    }
}