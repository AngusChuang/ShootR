﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShootR
{
    public class LifeController
    {
        public const double LEVEL_UP_LIFE_INCREASE = 1.25;

        public event DeathEventHandler OnDeath;

        public LifeController(double life)
        {
            MaxLife = life;
            Health = MaxLife;
            Alive = true;
        }

        public Collidable Host { get; set; }
        public double Health { get; protected set; }
        public double MaxLife { get; protected set; }
        public bool Alive { get; protected set; }

        public void Hurt(double life, Collidable hurtBy = null)
        {
            Health -= life;

            // Dead
            if (Health <= 0)
            {
                Health = 0;
                Alive = false;

                if (OnDeath != null)
                {
                    OnDeath(Host, new DeathEventArgs(hurtBy));
                }
            }
        }

        public void Heal(double life)
        {
            Alive = true;
            Health += life;
        }

        public void HealFull()
        {
            Alive = true;
            Health = MaxLife;
        }        
    }
}