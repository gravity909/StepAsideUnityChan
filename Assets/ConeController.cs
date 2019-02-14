using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeController : MonoBehaviour {

    //unityChanを追加
    private GameObject unityChan;

    // Use this for initialization
    void Start ()
    {

        //シーン中のunityChanオブジェクトを取得
        this.unityChan = GameObject.Find("unitychan");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //オブジェクトが画面外に出た場合
        //if (10 < this.unityChan.transform.position.z - this.transform.position.z)
        //{
        //    //オブジェクトを破棄
        //    Destroy(this.gameObject);
        //}
    }
}
