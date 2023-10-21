using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource gunAudio;
    private float time = 0.0f;
    public float interpolationPeriod = 1.0f;
    public GameObject Ball_R;
    public GameObject Ball_G;
    public GameObject Ball_B;
    public float gunSpeed=2000f;
    public GameObject explosionPrefab;
    private List<GameObject> bullets = new List<GameObject>();
      private List<GameObject> ballPrefabs = new List<GameObject>();
    void Awake()
    {
        gunAudio=GetComponent<AudioSource>();
    }
    
    void Start()
    {
        ballPrefabs.Add(Ball_R);
        ballPrefabs.Add(Ball_G);
        ballPrefabs.Add(Ball_B);
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            this.Shoot();
        }
        this.time += Time.deltaTime;
        if (this.time >= this.interpolationPeriod) {
            this.time = 0.0f;
            for (int i = 0; i < bullets.Count; i++) {
                if ( bullets[i].transform.position.y < -10) {
                    Destroy(bullets[i]);
                    bullets.RemoveAt(i);
                }
            }
        }
        
    }

    void Shoot() {
         int randomIndex = Random.Range(0, ballPrefabs.Count);
        GameObject selectedBallPrefab = ballPrefabs[randomIndex];
        GameObject bullet = Instantiate(selectedBallPrefab, this.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * gunSpeed);
        this.bullets.Add(bullet);
        gunAudio.Play();
    }
    void Explode(Vector3 position)
    {
        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        ParticleSystem particleSystem = explosion.GetComponent<ParticleSystem>();
        particleSystem.Play();
    }
}
