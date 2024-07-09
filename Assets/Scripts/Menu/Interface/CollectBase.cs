using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectBase : MonoBehaviour
{
    public string compareTag = "Player";

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
        //Destroy(gameObject);
        gameObject.SetActive(false);
       
    }

    protected virtual void OnCollected()
    {
        // Este método pode ser sobrescrito nas classes derivadas
    }
}

