using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
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
      CreateHitSound(enemyHit, other.gameObject);
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
      CreateHitSound(enemyHit, other.gameObject);
      Destroy(this.gameObject);
    }

  }
  private void CreateHitSound(AudioClip audioClip, GameObject other=null) //dodany wlasna metode gdyz playclipatpoint nie działa poprawnie w tym przypadku
  {
    //AudioSource.PlayClipAtPoint(audioClip, transform.position);

    GameObject inti;
    GameObject newObj = new GameObject("HitSound");
    if(other != null){
      inti = Instantiate(newObj, other.transform.localPosition, Quaternion.Euler(0, 0, 0));
      TextMeshPro text = inti.AddComponent<TextMeshPro>();
      text.SetText("-"+damage.ToString("F1"));
      text.fontSize = 3f;
      text.color = new Color32(97, 17, 17, 200);
      inti.GetComponent<RectTransform>().sizeDelta = new Vector2(2f, 1.5f);
      inti.transform.position = other.transform.position;
    } else {
      inti = Instantiate(newObj, transform);
    }
    AudioSource audioSource = inti.AddComponent<AudioSource>();
    audioSource.clip = audioClip;
    audioSource.outputAudioMixerGroup = mixer;
    audioSource.volume = 0.01f;
    audioSource.Play();
    Destroy(newObj);
    Destroy(inti, audioClip.length + 0.2f);
  }
}
