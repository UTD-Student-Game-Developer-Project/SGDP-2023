using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Weapons
{
    public class GunBasic : WeaponBase
    {
        [Header("Stats")]
        [SerializeField]
        int _magazineSize;
        float _reloadTime;
        
        [SerializeField, ReadOnly]
        int _bulletsLeft;

        [Header("References")]
        [SerializeField, HighlightIfNull]
        protected BulletBasic _bulletPrefab;
        
        [SerializeField, HighlightIfNull]
        protected Transform _gunTip;
        
        bool _reloading;

        protected override void Awake()
        {
            base.Awake();
            
            _bulletsLeft = _magazineSize;
        }
        
        protected override void OnAttack()
        {
            if (_reloading)
            {
                Debug.Log("The gun is still reloading...");
                return;
            }

            if (_bulletsLeft <= 0)
            {
                StartCoroutine(reload());
                return;
            }
            
            _bulletPrefab.Spawn(_gunTip.position, _gunTip.rotation);
            _bulletsLeft--;
        }

        IEnumerator reload()
        {
            _reloading = true;
            
            yield return new WaitForSeconds(_reloadTime);
            _reloading = false;
            
            _bulletsLeft = _magazineSize;
        }
    }
}
