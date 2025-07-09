using System;
using UnityEngine;

public class Vezbe1 : MonoBehaviour
{
    [SerializeField] private int score;


    public void Score(int amount)
    {
        score += amount;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Sphere sphere))
        {
            
        }
        Debug.Log(other.gameObject.name);
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log($"On collision Exit");
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log($"On collision Stay");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"On trigger Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Sphere sphere))
        {
           
        }
        Debug.Log($"On trigger exit");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"On trigger stay");
    }
}
