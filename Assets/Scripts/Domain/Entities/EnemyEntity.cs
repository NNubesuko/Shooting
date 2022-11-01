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
    public float magnification;
    public Vector2[] moveTargetTable;
    public float generateTime;
    public Vector2 initPosition;

}