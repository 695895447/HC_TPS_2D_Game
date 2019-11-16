using UnityEngine;

public class classwork_if : MonoBehaviour
{
    public int HP;
    void Update()
    {

            if (HP >= 70 && HP <= 100)
            {
                print("安全了");
            }
            else if (HP < 70 && HP >= 50)
            {
                print("警告");
            }
            else if (HP >= 20 && HP < 50)
            {
                print("危險");
            }
            else if (HP < 20)
            {
                print("快死了");
            }
        
    }
}
