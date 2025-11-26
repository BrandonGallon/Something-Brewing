using UnityEngine;
public class TestPotion : Potion
{
    public float damageAmount = 25f;
    public float destroyDelay = 0.5f;

    public void ApplyToEnemy(Enemy enemy)
    {
        if (enemy != null)
        {
            enemy.TakeDamage(damageAmount);
            Debug.Log(PotionName + " hit " + enemy.enemyName + " for " + damageAmount + " damage!");
        }
    }
}
