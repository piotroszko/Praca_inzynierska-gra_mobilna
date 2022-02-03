using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ProjectileManager : MonoBehaviour
{
  float speed;
  float damage;
  bool right = false;
  public AudioClip groundHit;
  public AudioClip enemyHit;
  public AudioMixerGroup mixer;
  public void Setup(Sprite projectileSprite = null, float speed = 20f, float damage = 18f)
  {
    this.speed = speed;
    this.damage = damage;
    if (projectileSprite)
      gameObject.GetComponent<SpriteRenderer>().sprite = projectileSprite;
  }
  void Start()
  {
    Object.Destroy(gameObject, 0.8f);
    if (transform.localRotation.eulerAngles.z == 90)
      this.right = true;

  }

  void Update()
  {
    if (right)
      transform.Translate((-transform.right * speed * Time.deltaTime));
    else
      transform.Translate((transform.right * speed * Time.deltaTime));
  }
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      other.gameObject.GetComponent<EnemyManager>().health -= this.damage;
      CreateHitSound(enemyHit);
      Destroy(this.gameObject);
    }
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Trap" || other.gameObject.tag == "Spikes")
    {
      CreateHitSound(groundHit);
      Destroy(this.gameObject);
    } else if ( other.gameObject.tag == "SwordBoss") {
      other.gameObject.GetComponent<SwordBossHealth>().Hit((int)this.damage);
      CreateHitSound(enemyHit);
      Destroy(this.gameObject);
    }

  }
  private void OnTriggerStay2D(Collider2D other)
  {
    if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Trap" || other.gameObject.tag == "Spikes")
    {
      CreateHitSound(groundHit);
      Destroy(this.gameObject);
    } else if ( other.gameObject.tag == "SwordBoss") {
      other.gameObject.GetComponent<SwordBossHealth>().Hit((int)this.damage);
      CreateHitSound(enemyHit);
      Destroy(this.gameObject);
    }
  }
  private void CreateHitSound(AudioClip audioClip) //dodany wlasna metode gdyz playclipatpoint nie działa poprawnie w tym przypadku
  {
    AudioSource.PlayClipAtPoint(audioClip, transform.position);
    GameObject newObj = new GameObject("HitSound");
    AudioSource audioSource = newObj.AddComponent<AudioSource>();
    audioSource.clip = audioClip;
    audioSource.outputAudioMixerGroup = mixer;
    audioSource.volume = 0.01f;
    Instantiate(newObj, transform);
    audioSource.Play();
    Destroy(newObj, audioClip.length + 0.1f);
  }
}
