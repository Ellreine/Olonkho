using System.Collections;
using UnityEngine;

public class PlayClearing : MonoBehaviour
{
    [SerializeField] private GameObject clearEffect;
    [SerializeField] private float clearTimer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Clearing());
        }

    }

    private IEnumerator Clearing()
    {
        clearEffect.SetActive(true);
        yield return new WaitForSeconds(clearTimer);
        clearEffect.SetActive(false);
    }
}
