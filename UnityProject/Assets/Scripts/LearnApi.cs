using UnityEngine;

public class LearnApi : MonoBehaviour
{
    public Transform TransformA;
    public Camera cam;
    public AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        print((Random.value)*100);
        print(Random.Range(1.0f, 100));
        print("\n");
        print(cam.depth);
        cam.depth = 2;//cam深度
        TransformA.position = new Vector3(1, 0, 0);//改變位置

        aud.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        /*float a;
        a = Mathf.PI;
        print(a);*/

        TransformA.position = new Vector3(1, 0, 0);
        TransformA.Rotate(0, 0, 10);
    }
}
