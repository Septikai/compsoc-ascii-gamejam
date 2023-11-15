using compsoc_ascii_gamejam.Characters;
using compsoc_ascii_gamejam.Characters.NonPlayerCharacter;
using compsoc_ascii_gamejam.Characters.Player;

namespace compsoc_ascii_gamejam.Combat;

public class Combat
{
    private readonly NonPlayerCharacter _enemy;
    private bool _isPlayerTurn;
    private readonly Random _random = new Random();
    private int _tempStrBonus = 0;
    private int _tempDfcBonus = 0;

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
        CombatManager.GetInstance().GetCombatMenu().UpdateMenu();
        if (!this._isPlayerTurn)
        {
            EnemyAttack();
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
        System.Threading.Thread.Sleep(200);
        this._isPlayerTurn = !this._isPlayerTurn;
    }

    private void EnemyAttack()
    {
        var damage = this._enemy.GetStrength() - PlayerCharacter.GetPlayerCharacter().GetStrength() + _tempDfcBonus;
        this._tempDfcBonus = 0;
        if (damage >= 0)
        {
            var playerDead = PlayerCharacter.GetPlayerCharacter().Damage(damage);
            if (playerDead) CombatManager.GetInstance().GetCombatMenu().Defeat();
        }
        else
        {
            var enemyDead = this._enemy.Damage(-damage);
            if (enemyDead) CombatManager.GetInstance().GetCombatMenu().Victory();
        }
        this.PassTurn();
    }

    public void Attack()
    {
        if (!this._isPlayerTurn) return;
        var damage = this.CombatStrengthTest(PlayerCharacter.GetPlayerCharacter().GetStrength() + this._tempStrBonus,
            this._enemy.GetStrength());
        this._tempStrBonus = 0;
        if (damage >= 0)
        {
            var enemyDead = this._enemy.Damage(damage);
            if (enemyDead) CombatManager.GetInstance().GetCombatMenu().Victory();
        }
        else
        {
            var playerDead = PlayerCharacter.GetPlayerCharacter().Damage(-damage);
            if (playerDead) CombatManager.GetInstance().GetCombatMenu().Defeat();
        }
    }

    public void Defend()
    {
        if (!this._isPlayerTurn) return;
        this._tempDfcBonus += 2;
    }

    public void Inventory()
    {
        if (!this._isPlayerTurn) return;
        CombatManager.GetInstance().GetCombatMenu().ToggleShowInventory();
    }

    public void UseItem(InventoryItem item)
    {
        Characters.Player.Inventory.GetInventory().RemoveFromInventory(item, 1, true);
        var bonus = item.GetStatEffect();
        var stat = item.GetStatType();
        switch (stat)
        {
            case CharacterStat.MaxHealth:
                PlayerCharacter.GetPlayerCharacter().ModifyStat(CharacterStat.MaxHealth, bonus);
                break;
            case CharacterStat.Health:
                PlayerCharacter.GetPlayerCharacter().ModifyStat(CharacterStat.Health, bonus);
                break;
            case CharacterStat.Strength:
                this._tempStrBonus += bonus;
                break;
            case CharacterStat.Defence:
                this._tempDfcBonus += bonus;
                break;
        }
    }

    private int CombatStrengthTest(int testVal, int targetVal)
    {
        var randVal = _random.Next(1, 7);
        CombatManager.GetInstance().GetCombatMenu().SetDieValue(randVal);
        return (testVal + randVal) - targetVal;
    }
}