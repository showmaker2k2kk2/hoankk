using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationtrigger : MonoBehaviour
{
    private Player player=>GetComponentInParent<Player>();
    private void AnimationTrigger()
    {
        player.AnimationTrigger(); 
    }

    private void attackdame()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(player.attackcheck.position, player.attackcheckRadius);
        foreach (var hit in collider)
        {
            if (hit.GetComponent<Enemy>() != null)
                hit.GetComponent<Enemy>().Damage();
        }
                
    }
}
