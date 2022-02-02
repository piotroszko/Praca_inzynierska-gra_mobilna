using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageZone : MonoBehaviour
{
    public int damage = 15;
    public float frequencyAttack = 2f;
    private float lastAttackDate = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(Time.time - lastAttackDate > frequencyAttack) {
                other.gameObject.GetComponent<PlayerCombatController>().DamagePlayer(this.damage);
                lastAttackDate = Time.time;
            }
        }
    }
}
