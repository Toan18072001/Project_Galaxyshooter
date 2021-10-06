using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private Transform[] m_WayPoints;
    [SerializeField] private Projecttile _projecttile;
    [SerializeField] Transform fine_point;
    private int m_CurrentWayPointIndex;
    bool status_fine ;
    int Hp_enemy=4;
    [SerializeField] VFX des_par;
    SpawManager spaw;
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(enemy_fine());
        spaw = FindObjectOfType<SpawManager>();// duyệt tất cả các object ở trên screen lấy ra spawmanager.
    }

    // Update is called once per frame
    void Update()
    {
        int nextWayPoint = m_CurrentWayPointIndex + 1;
        if (nextWayPoint > m_WayPoints.Length - 1)
            nextWayPoint = 0;

        transform.position = Vector3.MoveTowards(transform.position, m_WayPoints[nextWayPoint].position, m_MoveSpeed * Time.deltaTime);
        if (transform.position == m_WayPoints[nextWayPoint].position)
            m_CurrentWayPointIndex = nextWayPoint;

        // tính góc quay thông qua hướng di chuyển
        Vector3 direction = m_WayPoints[nextWayPoint].position - transform.position;
        // tính góc của direction
        float aglen = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//(nhân vào để chuyển qua hệ tọa độ 360
                                                                            // nếu truyền direction nó bị nhảy trc thì đổi lại x trc y sau và ngc lại            
        transform.rotation = Quaternion.AngleAxis(aglen + 90, Vector3.forward);
    }

    public void hit(int damge)
    {
        Hp_enemy -= damge;
        if (Hp_enemy <= 0)
        {
            // spaw.Relase(this);
            Destroy(gameObject);
            Vector3 des = transform.position;
            Instantiate(des_par, des, Quaternion.identity, null);
            _gameManager.update_Score(1);
            spaw.IsClaer(1);
        }
    }

    public void init(Transform[] arr_T)
    {
        m_WayPoints=arr_T;
       
        // đặt vị trí  sinh ra cho cho enemy đầu trên
        transform.position = m_WayPoints[0].position;

    }
   
    IEnumerator enemy_fine()
    {
        yield return new WaitForSeconds(2f);
        status_fine = true;
        if (status_fine)
        {
            Instantiate(_projecttile, fine_point.position, Quaternion.identity, null);
            
        }
        status_fine = false; 
        yield return new WaitForSeconds(7f);
        StartCoroutine(enemy_fine());
        
       
    }
}
