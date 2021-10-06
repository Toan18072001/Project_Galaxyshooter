using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroud : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 pos;
    float speed = 3f;
    void Start()
    {
        pos = new Vector3(-0.2f,20.93f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -19.7)
        {
            transform.position = pos;
        }
    }
}
