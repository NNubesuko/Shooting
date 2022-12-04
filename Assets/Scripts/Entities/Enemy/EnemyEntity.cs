using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyEntities {

    public EnemyEntity[] entities;

}

[Serializable]
public class EnemyEntity {

    public int hp;
    public int ap;
    public int moveSpeed;
    public int point;
    public float magnification;
    public float moveTargetSwitchingInterval;
    public Vector2[] moveTargetTable;
    public float generateTime;
    public Vector2 initPosition;

}

// hp
// ap
// moveSpeed
// magnification
// moveTargetTable
// time
