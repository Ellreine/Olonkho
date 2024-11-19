using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    private int ammo;
    [SerializeField] private GameObject activeArrow;
    [SerializeField] private float trapTimer;
    private float cooldownTimer;
    private bool trapActive;
    private bool nextArrow;

    [Header("SFX")]
    [SerializeField] private AudioClip arrowSound;

    void Start()
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.GetComponent<Arrow>().FindTrap(this);
        }
        Reload();
        nextArrow = true;
    }

    private void Update()
    {
        if (trapActive)
        {
            if (nextArrow)
            {
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0)
                {
                    Attack();
                    nextArrow = false;
                }
            }
        }
    }

    private void Attack()
    {
        ammo--;
        activeArrow.SetActive(true);
        activeArrow.GetComponent<Arrow>().ActivateProjectile();
        if (ammo>=0)
        {
            activeArrow = arrows[ammo];
            activeArrow.gameObject.SetActive(true);
        }
        else
        {
            Reload();
        }
    }

    private void Reload()
    {
        ammo = arrows.Length - 1;
        activeArrow = arrows[ammo];
        cooldownTimer = trapTimer;
    }


    public void ClickActivate(bool state)
    {
        trapActive = state;
    }

    public void NextArrow()
    { 
        nextArrow = true;
    }

}