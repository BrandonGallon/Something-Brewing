using System.Collections;
using UnityEngine;

public class NuclearPotion : Potions
{
    public float explosionDamage = 100f;
    public float radiationDamage = 5f;

    public override void ApplyEffect(GameObject Enemy)
    {
        base.ApplyEffect(Enemy);


        Collider[] hitObjects = Physics.OverlapSphere(Enemy.transform.position, radiationDamage);

        foreach (var hit in hitObjects)
        {
            var enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(explosionDamage);

            }
        }
    }

    private IEnumerator ApplyRadiation(Enemy enemy)
    {
        float timer = 0f;

        while (timer < DamageDuration)
        {
            enemy.TakeDamage(radiationDamage);
            yield return new WaitForSeconds(1f);
            timer++;
        }
    }
}
