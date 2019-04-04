using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (IsAttackerInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners) {
            bool isCloseEnough = (Mathf.Approximately(spawner.transform.position.y, transform.position.y));

            if (isCloseEnough) {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane() {
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        } else {
            return true;
        }
    }

    public void Fire() {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}