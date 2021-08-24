using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingScript : MonoBehaviour
{
    public Weapons Wp;
    void start()
    {
        Wp = GetComponent<Weapons>();
    }
    //unlike attackhandler, which is responsible for guiding player attacks, this script is a general "idc who's attacking,
    //you're calling this script for the number crunching. 
    // Start is called before the first frame update
    public int PHitrate(PlayerUnit player, EnemyUnit enemy, Weapons.Weapon weapon)
    {
        //calculating hitrate 
        //a precise formula will be figured out later. 
        int basehitrate = Wp.getBaseHitrate(weapon);
        //player skills can be figured out later
        basehitrate -= enemy.speed;
        return basehitrate;
    }
    public int PAttackDamage(PlayerUnit player, EnemyUnit enemy, Weapons.Weapon weapon)
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += player.pAttack;
        basedamage -= enemy.pDefense;
        return basedamage;
        
    }
    public int PMagicAttackDamage(PlayerUnit player, EnemyUnit enemy, Weapons.Weapon weapon) //we will implement magic stuff afterwards
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += player.mAttack;
        basedamage -= enemy.mDefense;
        return basedamage;
    }
    public int PCritrate(PlayerUnit player, EnemyUnit enemy, Weapons.Weapon weapon)
    {
        int basecritrate = Wp.getBaseCritrate(weapon);
        //theres a lot of stuff we can do w this
        return basecritrate;
    }
    public int PStaminaReduction(PlayerUnit player, EnemyUnit enemy, Weapons.Weapon weapon)
    {
        //ignore for now 
        return 5;
    }
    public int EHitrate(PlayerUnit player, EnemyUnit enemy, Weapons.Weapon weapon)
    {
        int basehitrate = Wp.getBaseHitrate(weapon);
        //player skills can be figured out later
        basehitrate -= player.speed;
        return basehitrate;
    }
    public int ECritrate(PlayerUnit player, EnemyUnit enemy, Weapons.Weapon weapon)
    {
        int basecritrate = Wp.getBaseCritrate(weapon);
        //theres a lot of stuff we can do w this
        return basecritrate;
    }
    public int EAttackDamage(PlayerUnit player, EnemyUnit enemy, Weapons.Weapon weapon)
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += enemy.pAttack;
        basedamage -= player.pDefense;
        return basedamage;
        
    }
    public int EMagicAttackDamage(PlayerUnit player, EnemyUnit enemy, Weapons.Weapon weapon) //we will implement magic stuff afterwards
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += enemy.mAttack;
        basedamage -= player.mDefense;
        return basedamage;

    }
    public int EStaminaReduction(PlayerUnit player, EnemyUnit enemy, Weapons.Weapon weapon)
    {
        //ignore for now
        return 5;
        
    }
}

