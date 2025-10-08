using UnityEngine;//InstantiateやGetComponentなどの関数を利用できるようにするライブラリ

public class GameManager : MonoBehaviour
{
    //1)素材関連
    public GameObject cardPrefab;//Cardプレハブ
    public Sprite backImage;//裏面
    public Sprite frontImage;//表面

    //2)カード情報を扱うための準備
    private SpriteRenderer sr;//画像表示に関する
    private BoxCollider2D col;//当たり判定に関する
    private bool isFront = false;//false=裏、true=表

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //3)カード情報を取得して裏向きにセット(Instantiateで生成)
        //Instantiate(何を, 位置, 回転); 
        //GameObject newCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);//Vector3.zeroでベクトル3方向(x,y,z)が0,Quaternion.identityで回転なし
        GameObject newCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);
        sr = newCard.GetComponent<SpriteRenderer>();//カードの画像情報を取得
        col = newCard.GetComponent<BoxCollider2D>();//カードの当たり判定を取得
        ShowBack();//最初は裏にセット→中身は4)へ
    }

    // Update is called once per frame
    void Update()
    {
        //左クリックしたら(0は左,1は右)
        if (Input.GetMouseButtonDown(0))
        {
            //マウスクリック位置を取得
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mp.z = 0;

            //マウスの位置(mp)がColliderの範囲だったら
            if (col.OverlapPoint(mp))
            {
                if (isFront)
                {
                    ShowBack();//表向きなら裏向きへ
                }
                else
                {
                    ShowFront();//そうでなければ表向きへ
                }
            }
        }

    }

    //コンパイルされる言語は関数を使用する箇所の下で宣言してもOK（可視性が向上する）
    //Showback()の中身/裏向きにセット
    void ShowBack()
    {
        sr.sprite = backImage;
        isFront = false;//今、裏向きですよという情報を保持
    }

    //5)表向きにセット
    void ShowFront()
    {
        sr.sprite = frontImage;
        isFront = true;//今、表向きですよという情報を保持
    }
}
