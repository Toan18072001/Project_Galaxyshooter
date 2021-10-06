using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    [SerializeField]
    float move_speed = 5f;
    [SerializeField]
    Vector2 direction;
    int damge=1;
    [SerializeField] VFX hit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IE_des());
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * move_speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="enemy")
        {
            Destroy(gameObject);
            Enemy_controller enemy;
            collision.gameObject.TryGetComponent(out enemy);
            enemy.hit(damge);
            Vector3 hitpos = collision.ClosestPoint(transform.position);// vấy vị trí va cha viên đạn vơi enemy
            Instantiate(hit, hitpos, Quaternion.identity, null);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);// Phải hủy viên đạn vì dùng trigger nên nó đi xuyên wa gameobject. nếu nó gặp đối tượng khác sẽ bị lỗi.
            Player_Script player;
            collision.gameObject.TryGetComponent(out player);
            player.hit(damge);
            Vector3 hitpos = collision.ClosestPoint(transform.position);// vấy vị trí va cha viên đạn vơi player
           // Instantiate(hit, hitpos, Quaternion.identity, null);
        }
    }
    IEnumerator IE_des()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
