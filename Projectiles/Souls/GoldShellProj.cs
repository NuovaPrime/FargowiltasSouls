﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Projectiles.Souls
{
    public class GoldShellProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Shell");
        }

        public override void SetDefaults()
        {
            projectile.width = 56;
            projectile.height = 56;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            if (player.dead)
            {
                modPlayer.GoldShell = false;
            }

            if (!(modPlayer.GoldShell))// || !Soulcheck.GetValue("Chlorophyte Leaf Crystal"))
            {
                projectile.Kill();
                return;
            }

            projectile.position.X = Main.player[projectile.owner].Center.X - projectile.width / 2;
            projectile.position.Y = Main.player[projectile.owner].Center.Y - projectile.height / 2;
        }
    }
}