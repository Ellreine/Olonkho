using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffingTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image picture;
    private float cooldown;
    public bool isActive { get; private set; }
    public float _cooldown =>cooldown;

    private void Update()
    {
        cooldown-= Time.deltaTime;
        timerText.text = Convert.ToInt32(cooldown).ToString();
        if (cooldown <= 0)
        {
            NulifyPicture();
            gameObject.SetActive(false);
            BuffsImage.instance.Sorting();
        }

    }

    public Sprite GiveSprite()
    {
        return picture.sprite;
    }
    public void SetPicture(Sprite sprite, float cd)
    {
        cooldown = cd;
        picture.sprite = sprite;
        timerText.text = cooldown.ToString();
        isActive = true;
        gameObject.SetActive(true);
    }

    public void NulifyPicture()
    {
        cooldown = 0;
        picture.sprite = null;
        isActive = false;
    }

}
