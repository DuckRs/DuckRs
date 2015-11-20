using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Color = System.Drawing.Color;
using Version = System.Version;
using System.Net;
using System.Text.RegularExpressions;

namespace LeblanRc
{
    static class Program
     {
        public static Version AssVersion;
        public static readonly String CN = "LeBlanc";
        private static readonly List<Slide> ExistingSlide = new List<Slide>();
        private static bool leBlancClone;
        public static Spell.Targeted Q;
        public static Spell.Skillshot W;
        public static Spell.Skillshot E;
        public static Spell.Targeted R;
        private static ComboType vComboType = ComboType.ComboQR;
        private static ComboKill vComboKill = ComboKill.FullCombo;
        private static bool _isComboCompleted = true;
        
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
             }

        private static void OnLoadingComplete(EventArgs args)
        {
              return;
            }
             Q = new Spell.Targeted(SpellSlot.Q, 720);
            W = new Spell.Skillshot(SpellSlot.W, 600, SkillShotType.Circular, int.MaxValue, 1450, 220);
            E = new Spell.Skillshot(SpellSlot.E, 950, SkillShotType.Linear, 250, 1600, 70);
            R = new Spell.Targeted(SpellSlot.R, 720);
             ComboMenu = menu.AddSubMenu("Combo Menu", "comboMenu");

            ComboMenu.AddGroupLabel("Combo Menu");
            ComboMenu.Add("qCombo", new CheckBox("Use Q"));
            ComboMenu.AddSeparator();
            ComboMenu.Add("wCombo", new CheckBox("Use W"));
            ComboMenu.AddSeparator();
            ComboMenu.Add("eCombo", new CheckBox("Use E"));
            
            KillstealMenu = menu.AddSubMenu("Killsteal Menu", "killstealMenu");
            KillstealMenu.AddGroupLabel("Killsteal Menu");
            KillstealMenu.Add("ksQ", new CheckBox("Killsteal with Q"));
            KillstealMenu.Add("ksQR", new CheckBox("Killsteal with QR"));
            
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += OnDraw;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            
        }
        foreach (AIHeroClient enemy in HeroManager.Enemies)
            {
                if (drawKillable && enemy.Health < SpellManager.QDamage(enemy)
                    && Q.IsReady())
                    Drawing.DrawText(Drawing.WorldToScreen(enemy.Position), System.Drawing.Color.White, "Q = DEAD", 200);

                    if (drawKillable && enemy.Health < SpellManager.QDamage(enemy) + SpellManager.Q2Damage(enemy) + SpellManager.WDamage(enemy)
                    && enemy.Health > SpellManager.QDamage(enemy)
                    && Q.IsReady() && W.IsReady())
                    Drawing.DrawText(Drawing.WorldToScreen(enemy.Position), System.Drawing.Color.White, "Q + W = DEAD", 500);

                    if (drawKillable && enemy.Health < SpellManager.QDamage(enemy) + SpellManager.Q2Damage(enemy) + SpellManager.RQDamage(enemy)
                    && enemy.Health > SpellManager.QDamage(enemy) + SpellManager.WDamage(target)
                    && Q.IsReady() && R.IsReady())
                    Drawing.DrawText(Drawing.WorldToScreen(enemy.Position), System.Drawing.Color.White, "Q + R = DEAD", 500);

                if (drawKillable && enemy.Health < SpellManager.QDamage(enemy) + SpellManager.Q2Damage(enemy) + SpellManager.RQDamage(enemy) + SpellManager.RQ2Damage(enemy) + SpellManager.WDamage(enemy)
                    && enemy.Health > SpellManager.QDamage(enemy) + SpellManager.Q2Damage(enemy) + SpellManager.RQDamage(enemy)
                    && Q.IsReady() && R.IsReady() && W.IsReady())
                    Drawing.DrawText(Drawing.WorldToScreen(enemy.Position), System.Drawing.Color.White, "Q + R + W = DEAD", 500);

                if (drawKillable && enemy.Health < SpellManager.QDamage(enemy) + SpellManager.Q2Damage(enemy) + SpellManager.RQDamage(enemy) + SpellManager.RQ2Damage(enemy) + SpellManager.WDamage(enemy) + SpellManager.EDamage(enemy)
                    && enemy.Health > SpellManager.QDamage(enemy) + SpellManager.Q2Damage(enemy) + SpellManager.RQDamage(enemy) + SpellManager.RQ2Damage(enemy) + SpellManager.WDamage(enemy)
                    && Q.IsReady() && R.IsReady() && W.IsReady() && E.IsReady())
                    Drawing.DrawText(Drawing.WorldToScreen(enemy.Position), System.Drawing.Color.White, "Q + R + W + E = DEAD", 500);

                if (drawKillable && enemy.Health < SpellManager.QDamage(enemy) + SpellManager.Q2Damage(enemy) + SpellManager.RQDamage(enemy) + SpellManager.RQ2Damage(enemy) + SpellManager.WDamage(enemy) + SpellManager.EDamage(enemy) + SpellManager.E2Damage(enemy)
                    && enemy.Health > SpellManager.QDamage(enemy) + SpellManager.Q2Damage(enemy) + SpellManager.RQDamage(enemy) + SpellManager.RQ2Damage(enemy) + SpellManager.WDamage(enemy) + SpellManager.EDamage(enemy)
                    && Q.IsReady() && R.IsReady() && W.IsReady() && E.IsReady())
                    Drawing.DrawText(Drawing.WorldToScreen(enemy.Position), System.Drawing.Color.White, "Q + R + W + E + E2 = DEAD", 500);
            }
        }
    }
}
