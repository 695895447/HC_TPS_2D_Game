
public class pipe : Ground
{
    private void Start()
    {

    }
    //在相機外執行一次
    private void OnBecameInvisible()
    {
        Destroy(gameObject,1f);
    }
        //在相機外執行一次
    private void OnBecameVisible()
    {

    }
}
