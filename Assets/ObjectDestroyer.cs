using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    //カメラを追加
    private GameObject MainCamera;

    // Use this for initialization
    void Start () {
      
        //シーン中のカメラを取得
        MainCamera = Camera.main.gameObject;
    }


	
	// Update is called once per frame
	void Update () {

        //オブジェクトが画面外に出た場合
        if (0 > this.transform.position.z - this.MainCamera.transform.position.z)
        {
            //オブジェクトを破棄
            Destroy(this.gameObject);
        }
    }
}
