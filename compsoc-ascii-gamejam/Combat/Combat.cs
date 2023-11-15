using compsoc_ascii_gamejam.Characters.NonPlayerCharacter;
using compsoc_ascii_gamejam.Characters.Player;

namespace compsoc_ascii_gamejam.Combat;

public class Combat
{
    private NonPlayerCharacter _enemy;
    private bool _isPlayerTurn;

    public Combat(NonPlayerCharacter enemy)
    {
        this._enemy = enemy;
        this._isPlayerTurn = PlayerCharacter.GetPlayerCharacter().GetAgility() >= this._enemy.GetAgility() ? 
            true : false;
    }

    public NonPlayerCharacter GetEnemy()
    {
        return this._enemy;
    }

    public void AwaitEndOfTurn()
    {
        if (!this._isPlayerTurn)
        {
            // TakeEnemyTurn();
        }
        else
        {
            CombatManager.GetInstance().GetCombatMenu().AwaitPlayerAction();
        }
    }

    public bool IsPlayerTurn()
    {
        return this._isPlayerTurn;
    }

    public void PassTurn()
    {
        this._isPlayerTurn = !this._isPlayerTurn;
    }

    public void Attack()
    {
        if (!this._isPlayerTurn) return;
        
    }

    public void Defend()
    {
        if (!this._isPlayerTurn) return;
    }

    public void Inventory()
    {
        if (!this._isPlayerTurn) return;
    }
}