﻿using GTA.Native;
using GunshotWound2.Components.DamageComponents.WeaponDamageComponents;
using LeopotamGroup.Ecs;

namespace GunshotWound2.Systems.HitSystems.WeaponHitSystems
{
    [EcsInject]
    public class HeavyImpactHitSystem : BaseWeaponHitSystem
    {
        public HeavyImpactHitSystem()
        {
            WeaponHashes = new []
            {
                (uint) WeaponHash.Bat, 
                (uint) WeaponHash.Crowbar,
                (uint) WeaponHash.FireExtinguisher, 
                (uint) WeaponHash.Firework,
                (uint) WeaponHash.GolfClub, 
                (uint) WeaponHash.Hammer, 
                (uint) WeaponHash.PetrolCan, 
                (uint) WeaponHash.PoolCue, 
                (uint) WeaponHash.Wrench,
            };
        }
        
        protected override void CreateComponent(int pedEntity)
        {
            EcsWorld
                .CreateEntityWith<HeavyImpactDamageComponent>()
                .PedEntity = pedEntity;
        }
    }
}