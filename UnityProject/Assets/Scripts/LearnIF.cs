using UnityEngine;

public class LearnIF : MonoBehaviour
{
    public bool test=false;
    public bool boola =true;
    public bool boolb = false;
    public int a=1;
    public int b=0;
    public string prop;
    private void Update()
    {
        if (test)
        {
            print("123");
        }
        else if(a+b>0)
        {
            print("進來了");
        }
        if(prop=="使用紅藥水")
        {
            print("補血了");
        }
        if(prop=="使用藍藥水")
        {
            print("補魔了");
        }

    }
}
