using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour
{
    private Material materialWhite;
    private Material materialDefeault;
    [SerializeField] SpriteRenderer[] sprite;
    void Start()
    {
        materialWhite = Resources.Load("BossHit", typeof(Material)) as Material;

        for(int i = 0; i < sprite.Length; i++)
        {
            materialDefeault = sprite[i].material;
        }
    }

    public void EnableWhiteHit()
    {
        for (int i = 0; i < sprite.Length; i++)
        {
            sprite[i].material = materialWhite;
        }
    }

    public void DisableWhiteHit()
    {
        for (int i = 0; i < sprite.Length; i++)
        {
            sprite[i].material = materialDefeault;
        }
    }
}
