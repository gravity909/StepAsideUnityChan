using UnityEngine;
using System.Collections;
public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //unityChanを追加
    public GameObject unityChan;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //　次に敵が出現するまでの時間
    private float appearNextTime = 3;
    //　待ち時間計測フィールド
    private float elapsedTime;

    // Use this for initialization
    void Start()
    {
        //シーン中のunityChanオブジェクトを取得
        this.unityChan = GameObject.Find("unitychan");
        for (int i = 0; i <= 50; i += 15)
        {
            CreateItems();
        }

        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        ////距離カウンター
        //if (-159 > this.unityChan.transform.position.z && -160 < this.unityChan.transform.position.z)
        //{
        //    CreateItems();
        //}
        ////距離カウンター
        //if (-109 > this.unityChan.transform.position.z && -110 < this.unityChan.transform.position.z)
        //{
        //    CreateItems();
        //}
        ////距離カウンター
        //if (-59 > this.unityChan.transform.position.z && -60 < this.unityChan.transform.position.z)
        //{
        //    CreateItems();
        //}
        ////距離カウンター
        //if (-9 > this.unityChan.transform.position.z && -10 < this.unityChan.transform.position.z)
        //{
        //    CreateItems();
        //}

        //　経過時間を足す
        elapsedTime += Time.deltaTime;

        //経過時間が経ったら
        if (elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;

            CreateItems();
        }

        ////各オブジェクトが画面外に出た場合
        //if (10 < this.unityChan.transform.position.z - this.carPrefab.transform.position.z)
        //{
        //    //オブジェクトを破棄
        //    Destroy(this.carPrefab.gameObject);
        //}

        //if (10 < this.unityChan.transform.position.z - this.coinPrefab.transform.position.z)
        //{
        //    //オブジェクトを破棄
        //    Destroy(this.coinPrefab.gameObject);
        //}

        //if (10 < this.unityChan.transform.position.z - this.conePrefab.transform.position.z)
        //{
        //    //オブジェクトを破棄
        //    Destroy(this.conePrefab.gameObject);
        //}
    }

    //UnityChanの前方にアイテムを作る関数
    void CreateItems()
    {
        for (float i = this.unityChan.transform.position.z + 50; i < this.unityChan.transform.position.z + 100; i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 4)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (5 <= item && item <= 5)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    }
}

