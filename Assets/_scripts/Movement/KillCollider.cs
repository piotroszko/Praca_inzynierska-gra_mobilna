using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KillCollider : MonoBehaviour
{
    
    public float bounceForce;
    public GameObject dude;
    public Rigidbody2D rb;

// Start is called before the first frame update
void Start()
{
    rb = dude.GetComponent<Rigidbody2D>();
}
private void OnTriggerEnter2D(Collider2D other)
{
if(other.gameObject.tag == "Player")
{
    rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
    Destroy(gameObject);
}

}



}