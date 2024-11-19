using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;  
    private bool isActivated = false;
    
    void Start()
    {
            
    }

    public void ShowParticles()
    {
        if (!isActivated) { 
            isActivated = true;
            ps.Play();
            SoundHolder.Instance.PlaySound(SoundHolder.Instance.PickUpSouls);
        }
    }

   
    void Update()
    {
        
    }
}
