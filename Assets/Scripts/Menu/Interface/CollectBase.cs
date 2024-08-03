using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem collectParticleSystem;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        Debug.Log("Moeda Coletada");
        OnCollected();
         Invoke("DeactivateGameObject", 0.5f);
        
       
    }

    protected virtual void OnCollected()
    {
        if(collectParticleSystem != null) { 
            collectParticleSystem.Play();
        }
               
    }

    void DeactivateGameObject()
    {
        Destroy(gameObject);
    }

}

