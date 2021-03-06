﻿using MineNET.Entities;
using MineNET.Utils;
using MineNET.Values;
using System;

namespace MineNET.Init
{
    public class EffectInit : IDisposable
    {
        public static EffectInit In { get; private set; }

        public EffectInit()
        {
            EffectInit.In = this;
            this.Init();
        }

        public void Init()
        {
            this.Add(new Effect(Effect.SPEED, TextContainerUtils.ToString("effect.speed"), new Color(124, 175, 198)));
            this.Add(new Effect(Effect.SLOWNESS, TextContainerUtils.ToString("effect.slowness"), new Color(90, 108, 129), true));
            this.Add(new Effect(Effect.HASTE, TextContainerUtils.ToString("effect.haste"), new Color(217, 192, 67)));
            this.Add(new Effect(Effect.MINING_FATIGUE, TextContainerUtils.ToString("effect.mining_fatigue"), new Color(74, 66, 23), true));
            this.Add(new Effect(Effect.STRENGTH, TextContainerUtils.ToString("effect.strength"), new Color(147, 36, 35)));
            this.Add(new Effect(Effect.INSTANT_HEALTH, TextContainerUtils.ToString("effect.instant_health"), new Color(248, 36, 35)));
            this.Add(new Effect(Effect.INSTANT_DAMAGE, TextContainerUtils.ToString("effect.instant_damage"), new Color(67, 10, 9), true));
            this.Add(new Effect(Effect.JUMP_BOOST, TextContainerUtils.ToString("effect.jump_boost"), new Color(34, 255, 76)));
            this.Add(new Effect(Effect.NAUSEA, TextContainerUtils.ToString("effect.nausea"), new Color(85, 29, 74), true));
            this.Add(new Effect(Effect.REGENERATION, TextContainerUtils.ToString("effect.regeneration"), new Color(205, 92, 171)));
            this.Add(new Effect(Effect.RESISTANCE, TextContainerUtils.ToString("effect.resistance"), new Color(153, 69, 58)));
            this.Add(new Effect(Effect.FIRE_RESISTANCE, TextContainerUtils.ToString("effect.fire_resistance"), new Color(228, 154, 58)));
            this.Add(new Effect(Effect.WATER_BREATHING, TextContainerUtils.ToString("effect.water_breathing"), new Color(46, 82, 153)));
            this.Add(new Effect(Effect.INVISIBILITY, TextContainerUtils.ToString("effect.invisibility"), new Color(127, 131, 146)));
            this.Add(new Effect(Effect.BLINDNESS, TextContainerUtils.ToString("effect.blindness"), new Color(191, 192, 192), true));
            this.Add(new Effect(Effect.NIGHT_VISION, TextContainerUtils.ToString("effect.night_vision"), new Color(0, 0, 139)));
            this.Add(new Effect(Effect.HUNGER, TextContainerUtils.ToString("effect.hunger"), new Color(46, 139, 87), true));
            this.Add(new Effect(Effect.WEAKNESS, TextContainerUtils.ToString("effect.weakness"), new Color(72, 77, 72), true));
            this.Add(new Effect(Effect.POISON, TextContainerUtils.ToString("effect.poison"), new Color(78, 147, 49), true));
            this.Add(new Effect(Effect.WITHER, TextContainerUtils.ToString("effect.wither"), new Color(53, 42, 39), true));
            this.Add(new Effect(Effect.HEALTH_BOOST, TextContainerUtils.ToString("effect.health_boost"), new Color(248, 125, 35)));
            this.Add(new Effect(Effect.ABSORPTION, TextContainerUtils.ToString("effect.absorption"), new Color(36, 107, 251)));
            this.Add(new Effect(Effect.SATURATION, TextContainerUtils.ToString("effect.saturation"), new Color(255, 0, 255)));
            this.Add(new Effect(Effect.LEVITATION, TextContainerUtils.ToString("effect.levitation"), new Color(206, 255, 255)));
            this.Add(new Effect(Effect.FATAL_POISON, TextContainerUtils.ToString("effect.fatal_poison"), new Color(78, 147, 49), true));
        }

        public void Add(Effect effect)
        {
            MineNET_Registries.Effect.Add(effect.ID, effect);
        }

        public void Dispose()
        {
            EffectInit.In = null;
        }
    }
}
