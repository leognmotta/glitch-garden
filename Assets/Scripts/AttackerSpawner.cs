using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    [SerializeField] Attacker[] attackers;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 6f;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start() {
        while (spawn) {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));

            if (spawn)
                SpawnAttacker();
        }
    }

    public void StopSpawning() {
        spawn = false;
    }

    private void SpawnAttacker() {
        var attackerIndex = Random.Range(0, attackers.Length + 1);

        if (attackerIndex < attackers.Length) {
            Spawn(attackers[attackerIndex]);
        }
    }

    private void Spawn(Attacker myAttacker) {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}