using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{/*
    [SerializeField] private float lifetime;// khả năng tự hủy sau 1 khoảng thời gian
    private float curent_life_time;// check thời gian tự hủy
    particleFX_pool pool;*/
    private void OnEnable()
    {
       //curent_life_time = lifetime;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (curent_life_time <= 0)
        {
            pool.relase_VFX(this);
        }
        curent_life_time -= Time.deltaTime;*/
    }
  /*  public void setpool(particleFX_pool obj)
    {
        pool = obj;
    }*/
}
