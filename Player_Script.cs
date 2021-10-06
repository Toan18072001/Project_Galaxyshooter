using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [SerializeField]
    float move_speed=0;
    [SerializeField] private Projecttile _projecttile;
    [SerializeField] Transform fine_point;
    bool status_fine = false;
    int hp_Player=3;
    SpawManager spaw;
    [SerializeField] VFX shot;
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IE_Fine());
        spaw = FindObjectOfType<SpawManager>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vectical = Input.GetAxis("Vertical");
        Vector2 diection = new Vector2(horizontal, vectical);
        transform.Translate(diection * Time.deltaTime*move_speed);
        if (Input.GetKey(KeyCode.Space))
        {
            status_fine = true;
        }
    }
    IEnumerator IE_Fine()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            status_fine = true;
        }
        if (status_fine)
        {
            Instantiate(_projecttile, fine_point.position, Quaternion.identity, null);
            //spaw.spaw_shotfx(fine_point.position);
            Instantiate(shot, fine_point.position, Quaternion.identity, null);
            status_fine = false;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(IE_Fine());
    }

    public void hit(int damge)
    {
        hp_Player -= damge;
        if (hp_Player <= 0)
        {
            Destroy(gameObject);
            _gameManager.gameOver(false);
        }
    }
}
