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
    public int PHitrate(PlayerStats player, EnemyStats enemy, Weapons.Weapon weapon)
    {
        //calculating hitrate 
        //a precise formula will be figured out later. 
        int basehitrate = Wp.getBaseHitrate(weapon);
        //player skills can be figured out later
        basehitrate -= enemy.speed;
        return basehitrate;
    }
    public int PAttackDamage(PlayerStats player, EnemyStats enemy, Weapons.Weapon weapon)
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += player.pAttack;
        basedamage -= enemy.pDefense;
        return basedamage;
        
    }
    public int PMagicAttackDamage(PlayerStats player, EnemyStats enemy, Weapons.Weapon weapon) //we will implement magic stuff afterwards
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += player.mAttack;
        basedamage -= enemy.mDefense;
        return basedamage;
    }
    public int PCritrate(PlayerStats player, EnemyStats enemy, Weapons.Weapon weapon)
    {
        int basecritrate = Wp.getBaseCritrate(weapon);
        //theres a lot of stuff we can do w this
        return basecritrate;
    }
    public int PStaminaReduction(PlayerStats player, EnemyStats enemy, Weapons.Weapon weapon)
    {
        //ignore for now 
        return 5;
    }
    public int EHitrate(PlayerStats player, EnemyStats enemy, Weapons.Weapon weapon)
    {
        int basehitrate = Wp.getBaseHitrate(weapon);
        //player skills can be figured out later
        basehitrate -= player.speed;
        return basehitrate;
    }
    public int ECritrate(PlayerStats player, EnemyStats enemy, Weapons.Weapon weapon)
    {
        int basecritrate = Wp.getBaseCritrate(weapon);
        //theres a lot of stuff we can do w this
        return basecritrate;
    }
    public int EAttackDamage(PlayerStats player, EnemyStats enemy, Weapons.Weapon weapon)
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += enemy.pAttack;
        basedamage -= player.pDefense;
        return basedamage;
        
    }
    public int EMagicAttackDamage(PlayerStats player, EnemyStats enemy, Weapons.Weapon weapon) //we will implement magic stuff afterwards
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += enemy.mAttack;
        basedamage -= player.mDefense;
        return basedamage;

    }
    public int EStaminaReduction(PlayerStats player, EnemyStats enemy, Weapons.Weapon weapon)
    {
        //ignore for now
        return 5;
        
    }
    //functions above should be deleted upon below functions working 
    
    public int PHitrate(int playerstat, int enemystat, Weapons.Weapon weapon)
    {
        //calculating hitrate 
        //a precise formula will be figured out later. 
        int basehitrate = Wp.getBaseHitrate(weapon);
        //player skills can be figured out later
        basehitrate -= enemy.speed;
        return basehitrate;
    }
    public int PAttackDamage(int playerstat, int enemystat, Weapons.Weapon weapon)
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += player.pAttack;
        basedamage -= enemy.pDefense;
        return basedamage;
        
    }
    public int PMagicAttackDamage(int playerstat, int enemystat, Weapons.Weapon weapon) //we will implement magic stuff afterwards
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += player.mAttack;
        basedamage -= enemy.mDefense;
        return basedamage;
    }
    public int PCritrate(int playerstat, int enemystat, Weapons.Weapon weapon)
    {
        int basecritrate = Wp.getBaseCritrate(weapon);
        //theres a lot of stuff we can do w this
        return basecritrate;
    }
    public int PStaminaReduction(int playerstat, int enemystat, Weapons.Weapon weapon)
    {
        //ignore for now 
        return 5;
    }
    public int EHitrate(int playerstat, int enemystat, Weapons.Weapon weapon)
    {
        int basehitrate = Wp.getBaseHitrate(weapon);
        //player skills can be figured out later
        basehitrate -= player.speed;
        return basehitrate;
    }
    public int ECritrate(int playerstat, int enemystat, Weapons.Weapon weapon)
    {
        int basecritrate = Wp.getBaseCritrate(weapon);
        //theres a lot of stuff we can do w this
        return basecritrate;
    }
    public int EAttackDamage(int playerstat, int enemystat, Weapons.Weapon weapon)
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += enemy.pAttack;
        basedamage -= player.pDefense;
        return basedamage;
        
    }
    public int EMagicAttackDamage(int playerstat, int enemystat, Weapons.Weapon weapon) //we will implement magic stuff afterwards
    {
        int basedamage = Wp.getBaseAttack(weapon);
        basedamage += enemy.mAttack;
        basedamage -= player.mDefense;
        return basedamage;

    }
    public int EStaminaReduction(int playerstat, int enemystat, Weapons.Weapon weapon)
    {
        //ignore for now
        return 5;
        
    }

}

