using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("目前分數")]
    public int score;
    [Header("最高分數")]
    public int scoreHeight;
    [Header("水管")]
    public GameObject pipe;
    [Header("水管開始的x軸")]
    public float x;
    [Header("遊戲結算畫面")]
    public GameObject goFinal;
    //static 不會顯示在屬性Inspector面板上
    public static bool gameOver;
    public Text textScore;
    // 修飾詞權限：
    // private 其他類別無法使用
    // public 其他類別可以使用

    /// <summary>
    /// 加分。
    /// </summary>
    public void AddScore()
    {
        score++;
        //分數介面.文字內容＝分數.轉成字串();
        textScore.text=score.ToString();
    }

    /// <summary>
    /// 最高分數判定。
    /// </summary>
    private void HeightScore()
    {

    }

    /// <summary>
    /// 生成水管。
    /// </summary>
    private void SpawnPipe()
    {
        print("生成");
        Vector3 pos = new Vector3(x, Random.Range(-1.32F,1.19F ), 0);
        Instantiate(pipe, pos, Quaternion.identity);
    }

    /// <summary>
    /// 遊戲失敗。
    /// </summary>
    public void GameOver()
    {
        goFinal.SetActive(true);
        gameOver=true;
        CancelInvoke("SpawnPipe");//停掉Invoke
    }

    private void Start()
    {
        SpawnPipe();
        InvokeRepeating("SpawnPipe", 1f, 1f);
    }
}
