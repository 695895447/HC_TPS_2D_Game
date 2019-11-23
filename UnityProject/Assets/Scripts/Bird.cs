using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("跳躍高度"), Range(10, 2000)]
    public int jump = 250;
    [Header("旋轉角度"),Range(0,100)]
    public float angle=10;
    [Header("是否死亡"), Tooltip("用來判斷角色是否死亡，true 死亡，false 還沒死亡")]
    public bool dead;
    [Header("剛體")]
    public Rigidbody2D r2d;
    public GameManager gm;
    public GameObject goScore,goGM;//遊戲管理器跟分數
    public AudioSource aud;
    public AudioClip soundJump,soundHit,soundAdd;

    /// <summary>
    /// 小雞跳躍方法。
    /// </summary>
    private void Jump()
    {
        if(dead==true)
        {
            return;
        }
        //判段玩家有沒有按左鍵（滑鼠 跟 手機 也可)
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            aud.PlayOneShot(soundJump,1.5f);//跳一下的聲音
            r2d.Sleep(); //小雞物理 reset
            print("按了一下");
            r2d.gravityScale=1;//小雞重力
            r2d.AddForce(new Vector2(0,jump));//小雞跳多高
            goScore.SetActive(true);//顯示分數
            goGM.SetActive(true);//顯示GM
        }
        //Rigidbody2D.SetRotation(float) 設定角度
        //Rigidbody2D.velocity 加速度(二維向量x,y)
        r2d.SetRotation(angle* r2d.velocity.y);//小雞跳時的角度
    }
    /// <summary>
    /// 小雞死亡方法。
    /// </summary>
    private void Dead()
    {
        print("死了");
        dead=true;
        gm.GameOver();
    }
    //一秒一次
    private void Update()
    {

    }
    // 一幀一次
    private void FixedUpdate()
    {
        Jump();
    }
    private void OnCollisionEnter2D(Collision2D hit)
    {
        print(hit.gameObject.name);
        if(hit.gameObject.name=="地板")
        {
            Dead();
        }
    }
    private void OnTriggerEnter2D(Collider2D hit2)
    {
        if(hit2.gameObject.name=="水管 下"||hit2.gameObject.name=="水管 上")
        {
            aud.PlayOneShot(soundHit,2f);//撞墻的聲音
            Dead();
        }
    }
    private void OnTriggerExit2D(Collider2D hit3)
    {
        if(hit3.gameObject.name=="加分")
        {
            aud.PlayOneShot(soundAdd,1.5f);//撞墻的聲音
            gm.AddScore();
        }
    }
}
