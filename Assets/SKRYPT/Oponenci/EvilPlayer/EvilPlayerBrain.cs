using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerBrain : BaseBrain<EvilPlayerBrain>
{
    public Animator animator;

    public float damage;
    public float speed;
    public float jumpheight;
    public BaseWeapon weapon;
    


    void LoadStats()
    {
    }
}
