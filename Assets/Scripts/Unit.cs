using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Unit : NetworkBehaviour
{
    //private float baseHP { get; set; }
    //private float maxHP { get; set; }
    //private float HP { get; set; }

    //private float baseAttack { get; set; }
    //private float attack { get; set; }

    //private float baseDefense { get; set; }
    //private float defense { get; set; }

    //private float baseAgility { get; set; }
    //private float agility { get; set; }

    //private float baseEndurance { get; set; }
    //private float endurance { get; set; }

    //private float baseAttackRange { get; set; }
    //private float attackRange { get; set; }

    //private float shield { get; set; }

    //private float baseCritChance { get; set; }
    //private float critChance { get; set; }

    //private float baseCritDamage { get; set; }
    //private float critDamage { get; set; }

    //private float baseCritResist { get; set; }
    //private float critResist { get; set; }

    //private Vector3 position { set; get; }

    //private string[] status { set; get; }

    //public Unit(float _baseHP, float _baseAttack, float _baseDefense, float _baseAgility, float _baseEndurance, float _baseAttackRange,
    //    float _baseCritChance, float _baseCritDamage, float _baseCritResist)
    //{
    //    // set unit's base stats
    //    baseHP = _baseHP;
    //    baseAttack = _baseAttack;
    //    baseDefense = _baseDefense;
    //    baseAgility = _baseAgility;
    //    baseEndurance = _baseEndurance;
    //    baseAttackRange = _baseAttackRange;
    //    baseCritChance = _baseCritChance;
    //    baseCritDamage = _baseCritDamage;
    //    baseCritResist = _baseCritResist;

    //    // set unit's current stats to base stats
    //    HP = baseHP;
    //    attack = baseAttack;
    //    defense = baseDefense;
    //    agility = baseAgility;
    //    endurance = baseEndurance;
    //    attackRange = baseAttackRange;
    //    critChance = baseCritChance;
    //    critDamage = baseCritDamage;
    //    critResist = baseCritResist;
    //    shield = 0;
    //}

    //// stats get and set methods
    //public float getHP()
    //{
    //    return HP;
    //}
    //public float getAttack()
    //{
    //    return attack;
    //}
    //public float getDefense()
    //{
    //    return defense;
    //}
    //public float getAgility()
    //{
    //    return agility;
    //}
    //public float getEndurance()
    //{
    //    return endurance;
    //}
    //public float getAttackRange()
    //{
    //    return attackRange;
    //}
    //public float getCritChance()
    //{
    //    return critChance;
    //}
    //public float getCritDamage()
    //{
    //    return critDamage;
    //}
    //public float getCritResist()
    //{
    //    return critResist;
    //}

    //public void setAttack(float _attack)
    //{
    //    attack = _attack;
    //}
    //public void setDefense(float _defense)
    //{
    //    defense = _defense;
    //}
    //public void setAgility(float _agility)
    //{
    //    agility = _agility;
    //}
    //public void setEndurance(float _endurance)
    //{
    //    endurance = _endurance;
    //}
    //public void setAttackRange(float _attackRange)
    //{
    //    attackRange = _attackRange;
    //}
    //public void setCritChance(float _critChance)
    //{
    //    critChance = _critChance;
    //}
    //public void setCritDamage(float _critDamage)
    //{
    //    critChance = _critDamage;
    //}
    //public void setCritResist(float _critResist)
    //{
    //    critChance = _critResist;
    //}

    //void NewTurn()
    //{

    //}

    [SyncVar]
    Vector3 serverPosition;
    Vector3 serverPositionSmoothVelocity;

    void Update()
    {
        if(isServer)
        {

        }

        if(hasAuthority)
        {
            AuthorityUpdate();
        }

        if(!hasAuthority)
        {
            // 
            transform.position = Vector3.SmoothDamp(transform.position, serverPosition, ref serverPositionSmoothVelocity, 0.25f);
        }

        // TODO here: Animate movements
    }

    void AuthorityUpdate()
    {
        // Detect input commands and move
        float xMovement = Input.GetAxis("Horizontal") * 4 * Time.deltaTime;
        //float zMovement = Input.GetAxis("Vertical") * 4 * Time.deltaTime;
        transform.Translate(xMovement, 0, 0);

        // Update server of the movement
        CmdUpdatePosition(transform.position);
    }

    [Command]
    void CmdUpdatePosition(Vector3 newPosition)
    {
        // Validate legal movement
        //if(illegalMovementDetected)
        //{
        //    RpcFixPosition(newPosition);
        //}
        serverPosition = newPosition;
    }

    [ClientRpc]
    void RpcFixPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    } 
}
