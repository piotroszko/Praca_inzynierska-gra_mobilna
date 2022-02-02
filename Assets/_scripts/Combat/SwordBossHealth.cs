using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBossHealth : MonoBehaviour
{
    public GameObject ManagerBoss;
    void Start()
    {
        
    }
    public void Hit(int damage){
        ManagerBoss.GetComponent<SwordBossManager>().BossHit(damage);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
