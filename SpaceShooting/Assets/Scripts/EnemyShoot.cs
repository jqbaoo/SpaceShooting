/*
 * 
 * 项目：太空射击(Space Shooting)
 * 
 * Title: 敌人子弹发射
 * 
 * Description:
 *      具体作用：
 *      1、控制敌人的子弹发射
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private float _nextFire = 1f;
    public float floFireRate = 1.5f;
    public GameObject BultPrefab;
    public Transform bultPosition;

    void Update()
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + floFireRate;
            Instantiate(BultPrefab, bultPosition.position, bultPosition.rotation);

            AudioManager.PlayAudioEffectB("weapon_enemy");
        }
    }
}
