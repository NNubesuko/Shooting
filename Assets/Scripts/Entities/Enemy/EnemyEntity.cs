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
    public float moveSpeed;
    public float magnification;
    public Vector2[] moveTargetTable;
    public int point;
    public Vector2 initPosition;
    public float generateTime;

}