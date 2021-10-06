using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_path : MonoBehaviour
{
    [SerializeField]Transform[] m_waypoint;
    [SerializeField] Color _color;
    public Transform[] waypoint => m_waypoint;
    private void OnDrawGizmos()
    {
        
        if (m_waypoint != null && m_waypoint.Length > 1)
        {
            Gizmos.color = _color;
            for (int i=0;i<m_waypoint.Length-1; i++)
            {
                Transform _from = m_waypoint[i];
                Transform _to = m_waypoint[i + 1];
                
                Gizmos.DrawLine(_from.position, _to.position);
            }
            // kết tghucs vòng for còn 2 điểm chưa nối vs nhau t nối lại
            Gizmos.DrawLine(m_waypoint[0].position, m_waypoint[m_waypoint.Length - 1].position);
        }
    }
}
