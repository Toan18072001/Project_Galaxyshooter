using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour
{

    [SerializeField] bool active;
    [SerializeField] Enemy_controller enemy_frefab; //thay thế băng object pooling
    //[SerializeField] enemy_pool _enemy_pool;
    [SerializeField] int min_totalenemy;
    [SerializeField] int max_totalenemy;
    [SerializeField] int total_Ground;
    [SerializeField]float time_Enemy_Spaw;
    [SerializeField] Enemy_path[] m_E_P;
   // [SerializeField] particleFX_pool hit_FX;
    //[SerializeField] VFX hit_FX;
    int temp_enemy;
    int x;
    GameManager _gameManager;
    //[SerializeField] particleFX_pool shooting_FX;

    // Start is called before the first frame update
    void Start()
    {
        
        _gameManager = FindObjectOfType<GameManager>();
    }
    public void star_Starcoroutine()
    {
        StartCoroutine(spaw_Group(total_Ground));
    }
    IEnumerator IESpaw_Enemy(int total_enemy, Enemy_path path)
    {
        int i;
        //int total_enemy = Random.Range(min_totalenemy,max_totalenemy);
        for( i = 0; i<total_enemy; i++)
        {
            yield return new WaitUntil(() => active);
            yield return new WaitForSeconds(time_Enemy_Spaw);

             Enemy_controller enemy = Instantiate(enemy_frefab, transform); // sinh enemy từ prefab
           // Enemy_controller enemy = _enemy_pool.spaw_Enemy(path.waypoint[0].position, transform);// truyền cào vị trí xuất hiện đầu tiên của đường đi enemy
            
            enemy.init(path.waypoint);
        }
       
        
    }
    /* public void Relase( Enemy_controller obj)// hàm thay thế destroy ở spawmannager nên phải tạo 1 hàm tạm.
    {
        _enemy_pool.relase(obj);

    }*/
    IEnumerator spaw_Group(int groud)
    {
        for(int i=0; i < groud; i++)
        {
            int total = Random.Range(min_totalenemy, max_totalenemy);
            temp_enemy += total;
             x = total;
            Enemy_path path = m_E_P[Random.Range(0, m_E_P.Length)];// lấy ngaauc nhiên đường di chuyển cho enemy 
            yield return StartCoroutine(IESpaw_Enemy(total, path));
        }
        yield return new WaitForSeconds(3f);
    }
    // Update is called once per frame
    public void IsClaer(int emeny)
    {
        
       temp_enemy -= emeny;
       
        if (temp_enemy <= 0)
        {
            _gameManager.gameOver(true);
            _gameManager.update_Score(x);
        }
    }
    public void clear()
    {
        StopAllCoroutines();

    }
    /*public VFX spawfx(Vector3 position)
    {
        VFX hit_partical = Instantiate(hit_FX, transform);
        //hit_partical.setpool(hit_FX);
        return hit_partical;
    }
    public void relase(VFX obj)
    {
        //
        //hit_FX.relase_VFX(obj);
    }*/
    /*public VFX spaw_shotfx(Vector3 position)
    {
        VFX shot = shooting_FX.spaw_particle_fx(position, transform);
       // shot.setpool(shooting_FX);
        return shot;
    }
    public void relase_shotfx(VFX obj)
    {
        shooting_FX.relase_VFX(obj);
    }*/
}



//OBJECT POOLING

//Để hạn chế phân mảnh bộ nhớ  khi ta sử dụng INSTANTITE VSF DESSTROY OBJECT

/*[System.Serializable]
public class enemy_pool
{
    public Enemy_controller enemy_fre;
    public List<Enemy_controller> list_enemy;// list enemy chưa đc sử dụng
    public List<Enemy_controller> list_enemy_use;// list enemy đang sử dụng trên screen
   
    public Enemy_controller spaw_Enemy(Vector3 position, Transform parent )
    {
        if(list_enemy.Count == 0)// tìm enemy đầu tiên k có ta phải tạo mới cho nó
        {
            Enemy_controller enemy = GameObject.Instantiate(enemy_fre, parent);
            enemy.transform.position = position;// set   lại vị trí cho enemy
            list_enemy_use.Add(enemy);
           
            return enemy;
        }
        else  // Nếu đã có t sử dụng luôn enemy trong list
        {
                Enemy_controller enemy = list_enemy[0];
                enemy.gameObject.SetActive(true);
                enemy.transform.SetParent(parent);
                enemy.transform.position = position;
                list_enemy_use.Add(enemy);
                list_enemy.RemoveAt(0);
               
                return enemy;
           
            
        }
    }
    public void relase(Enemy_controller obj)// Hàm thayv thế hàm destroy
    {
        if (list_enemy_use.Contains(obj))// kiểm tra enemy nó có tồn tại trên screen k. có thì thì xóa nó và thêm vào list enemy chưa sử dụng
        {
            list_enemy_use.Remove(obj);
            list_enemy.Add(obj);
            obj.gameObject.SetActive(true);
        }
    }

}
*/

//[System.Serializable]
/*public class particleFX_pool
{
    public VFX prefab;
    public List<VFX> VFX_use;
    public List<VFX> VFX_un_use;
    public VFX spaw_particle_fx(Vector3 position, Transform parent)
    {
        if(VFX_un_use.Count == 0)
        {
            VFX particle = GameObject.Instantiate(prefab, parent);
            particle.transform.position = position;
            VFX_un_use.Add(particle);
            return particle;
        }
        else
        {
            VFX particle = VFX_use[0];
            particle.gameObject.SetActive(true);
            particle.transform.position = position;
            particle.transform.parent = parent;
            VFX_un_use.Add(particle);
            VFX_use.RemoveAt(0);
            return particle;
        }
    }
    public void relase_VFX(VFX obj)
    {
        if (VFX_un_use.Contains(obj))
        {
            VFX_un_use.Remove(obj);
            VFX_use.Add(obj);
            obj.gameObject.SetActive(true);
        }
    }
}*/