using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
[SerializeField] private GameObject hitEffectPrefab;
private bool hasHit = false;

private void OnCollisionEnter(Collision collision)
{

    if (!hasHit && hitEffectPrefab != null)
    {
        GameObject effectBullet=Instantiate(hitEffectPrefab, collision.contacts[0].point, Quaternion.identity);
        hasHit = true; 
        Destroy(effectBullet,0.1f);
    }

}
}