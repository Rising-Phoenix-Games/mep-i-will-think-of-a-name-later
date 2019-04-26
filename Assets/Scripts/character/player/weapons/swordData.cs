using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordData {

    public class MeleeAttack {

        public int damage;
        public float knockback;
        public GameObject player;

        public MeleeAttack(int d, float kb, GameObject pc) {
            damage = d;
            knockback = kb;
            player = pc;
        }

    }
    public static class Wooden
    {
        public static int damage = 10;
        public static int knockback = 10;
    }
}