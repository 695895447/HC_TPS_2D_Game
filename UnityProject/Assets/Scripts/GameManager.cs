using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [Header("分數介面")]
    public Text textScore;
    public Text textBest;

    //static 不會顯示在屬性Inspector面板上
    public static bool gameOver;
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
        HeightScore();
    }

    /// <summary>
    /// 最高分數判定。
    /// </summary>
    private void HeightScore()
    {
        if(score>PlayerPrefs.GetInt("最佳分數"))
        {
            PlayerPrefs.SetInt("最佳分數",score);
        }
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
    //UI一定要是public

    public void Replay()
    {
        //Application.LoadLevel("遊戲場景"); // 應用程式.載入場景("場景名稱")； 舊版
        SceneManager.LoadScene("遊戲場景");//新版API
    }
    public void Quit()
    {
        Application.Quit(); //使用 應用程式.離開
    }
    /// <summary>
    /// 遊戲失敗。
    /// </summary>
    public void GameOver()
    {
        goFinal.SetActive(true);
        gameOver=true;
        CancelInvoke("SpawnPipe");//停掉Invoke
        textBest.text=PlayerPrefs.GetInt("最佳分數").ToString();
    }

    //遊戲開始與載入場景會執行一次
    private void Start()
    {
        //靜態成員在重新載入後不會還原
        gameOver=false;
        SpawnPipe();
        InvokeRepeating("SpawnPipe", 1f, 1f);
        textBest.text=PlayerPrefs.GetInt("最佳分數").ToString();
        //螢幕設定解析度（寛，高，是否全螢幕）
        Screen.SetResolution(720,1280,false);
    }
}
