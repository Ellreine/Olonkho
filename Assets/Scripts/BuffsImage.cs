using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsImage : MonoBehaviour
{
    public static BuffsImage instance;
    [SerializeField] private BuffingTimer[] buffs;

    private void Awake()
    {
        instance = this;
    }

    public void Sorting ()
    {
        for (int i = 0; i< buffs.Length;i++)
        {
            if (!buffs[i].isActive)
            {
                    for (int j = i + 1; j < buffs.Length; j++)
                    {
                        if (buffs[j].isActive)
                        {
                            buffs[i].SetPicture(buffs[j].GiveSprite(), buffs[j]._cooldown);
                            buffs[j].NulifyPicture();
                            break;
                        }
                    }
                }
        }
    }

    public void ActivateBuff(Sprite sprite, float cd)
    {
        for (int i = 0; i < buffs.Length; i++)
        {
            if (!buffs[i].isActive)
            {
                buffs[i].SetPicture(sprite, cd);
                break;
            }
        }
    }

}
