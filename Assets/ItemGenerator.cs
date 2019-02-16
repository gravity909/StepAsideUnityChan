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

    //　アイテム生成場所
    private float appearPlace = -160;
   

    // Use this for initialization
    void Start()
    {
        //シーン中のunityChanオブジェクトを取得
        this.unityChan = GameObject.Find("unitychan");
       
            CreateItems();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (goalPos > this.unityChan.transform.position.z + 100)
        { 
            //距離カウンター
            if (this.unityChan.transform.position.z > appearPlace)
            {
              CreateItems();

              appearPlace += 15;
            }
        }
    }

    //UnityChanの前方にアイテムを作る関数
    void CreateItems()
    {
        for (float i = this.unityChan.transform.position.z + 35; i < this.unityChan.transform.position.z + 50; i += 15)
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

