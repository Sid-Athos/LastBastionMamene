using LastBastion;
using System;
using NUnit.Framework;
using SFML.System;
using System.Timers;

namespace Tests
{
    public class Tests
    {
        Bestiary beats = new Bestiary();

        [Test]
        public void T01_Game_Map_And_Castle_Are_Created_And_Not_Null()
        {
            Game sid = new Game();
            sid.Run();
            Assert.That(sid, Is.Not.Null);
            Map var = sid.Map;
            Assert.That(var, Is.Not.Null);
            Assert.That(var.GetCastle, Is.Not.Null);

        }

        [Test]
        public void T02_Create_Map_Create_Villagers()
        {
            Game sid = new Game();
            sid.Run();
            Assert.That(sid, Is.Not.Null);
            Map var = sid.Map;
            Assert.That(var, Is.Not.Null);

            var job = Guid.NewGuid().ToString();
            /**Villager v1 = new Villager(10.9f, 11.2f, 0.1f,job, 150, 4, 3, false, 2, 1.5f, var);
            job = Guid.NewGuid().ToString();
            Villager v2 = new Villager(10.5f, 11.2f,0.1f,job, 150, 4, 3, false, 2, 1.5f, var);

            Assert.That(v1, Is.Not.Null);
            Assert.That(v2, Is.Not.Null);*/
        }

        [Test]
        public void T03_Units_Are_Created_And_Can_Join_Units_List()
        {

            Game sid = new Game();
            sid.Run();
            Map var = new Map(sid);

            Assert.That(sid, Is.Not.Null);

            for(int i = 0; i < 4;i++)
            {

                var job1 = Guid.NewGuid().ToString();
                Barbar v1 = new Barbar(10.9f, 11.2f, "Gobelin", var);
                Assert.That(v1, Is.Not.Null);
            }
            Assert.That(var.BarbCount, Is.EqualTo(4));
        }

        [Test]
        public void T04_Units_Are_In_List_And_Attack_Correctly()
        {
            Game sid = new Game();
            sid.Run();
            Map var = new Map(sid);
            Assert.That(var, Is.Not.Null);
            
            Barbar v1 = new Barbar(10.9f, 11.2f, "Gobelin", var);
            Barbar v2 = new Barbar(0.9f, 11.2f, "Gobelin", var);

             for (int i = 0; i < 6; i++)
            {
                v1.Attack(v2);
            }
            Assert.That(v2.Life, Is.EqualTo(51));

        }

        [Test]
        public void T05_Enemy_Units_Find_Tower_Wherever_They_Are()
        {

            Game sid = new Game();
            sid.Run();
            Map var = new Map(sid);
            Assert.That(var, Is.Not.Null);
            Tower sido = new Tower(-1000000f, -10000000f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            for (int i = 0; i < 6; i++)
            {
                var job1 = Guid.NewGuid().ToString();
                Barbar v1 = new Barbar(10.9f, 11.2f, "Gobelin", var);
                v1.AcquireTarget();
                Assert.That(v1.EnemyTarget, Is.EqualTo(sido));
            }

            sido.Die();
            sido = new Tower(1000000f, 10000000f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            for (int i = 0; i < 6; i++)
            {
                Barbar v1 = new Barbar(10.9f, 11.2f,"Gobelin", var);
                v1.AcquireTarget();
                Assert.That(v1.EnemyTarget, Is.EqualTo(sido));
            }
        }

        [Test]
        public void T06_Towers_Switch_Targets_If_Enemy_Goes_Out_Of_Range()
        {
            Game sid = new Game();
            sid.Run();
            Map var = new Map(sid);
            Assert.That(var, Is.Not.Null);
            Tower sido = new Tower(10f, 12f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            
            var job1 = Guid.NewGuid().ToString();
            Barbar v1 = new Barbar(10.9f, 11.2f,"Gobelin", var);
            v1.AcquireTarget();
            Assert.That(v1.EnemyTarget, Is.EqualTo(sido));
            Tower faaaaaar = new Tower(100f, 120f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            while (!v1.Position.IsInRange(v1.Position, faaaaaar.Position, v1.Range))
            {
                v1.Position = v1.Position.Movement(v1.Position, faaaaaar.Position, 10, v1.Speed, v1.Range);
            }
            sido.AcquireTarget();
            Assert.That(sido.Target, Is.EqualTo(null));
            Barbar v2 = new Barbar(10.9f, 11.2f, "Gobelin", var);
            sido.AcquireTarget();
            Assert.That(sido.Target, Is.EqualTo(v2));

            /**sido = new Tower(1000000f, 10000000f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            for (int i = 0; i < 6; i++)
            {
                job1 = Guid.NewGuid().ToString();
                v1 = new Barbar(10.9f, 11.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
                v1.AcquireTarget();
                Assert.That(v1.EnemyTarget, Is.EqualTo(sido));
            }*/
        }

       /** [Test]
        public void T07_Archers_are_created_join_towers_within_limits_Plus_Tower_Upgrade()
        {
            Map var = new Map();

            Tower sido = new Tower(0.5f,10.5f,500,500,15,5,5,15f,1,var,"Tour","Du rohan");
            Archer v1 = new Archer(10.9f, 11.2f, 0.1f, "Archer", 150, 10, 3, false, 2, 0.002f, var);
            Archer v2 = new Archer(10.9f, 11.2f, 0.1f, "Archer", 150, 10, 3, false, 2, 0.002f, var);

            Assert.That(sido.ShowArchers(), Is.EqualTo(2));
            Assert.Throws<InvalidOperationException>(() => sido.AddArcher(v1));
            Assert.Throws<InvalidOperationException>(() => sido.AddArcher(v2));

            Assert.That(sido.ShowArchers(), Is.EqualTo(2));
            sido.Upgrade();
            Assert.That(sido.ShowArchers(), Is.EqualTo(4));
            Archer test = new Archer(0.5f, 10.4f, 2.0f, "Archer", 50, 5, 2, false, 3, 0.2f,var);
            Assert.Throws<InvalidOperationException>(() => sido.AddArcher(test));
        }*/

        [Test]
        public void T08_Projectiles_Created_Equal_To_Tower_Plus_Archar_Count_On_Attack()
        {
            Game sid = new Game();
            sid.Run();
            Map var = new Map(sid);

            Tower sido = new Tower(0.5f, 10.5f, 500, 500, 15, 5, 5, 10f, 1, var, "Tour", "Du rohan");
            var job1 = Guid.NewGuid().ToString();
            Barbar v1 = new Barbar(10.9f, 11.2f,"Gobelin", var);
            sido.AcquireTarget();
            Assert.That(sido.ShowArchers, Is.EqualTo(2));
            Assert.That(sido.AaCd.TimeStamp, Is.EqualTo(0));

            Assert.That(sido.Target, Is.EqualTo(v1));
            sido.Attack(sido.Target);
            Assert.That(sido.ProjList.Count, Is.EqualTo(3));

        }

        [Test]
        public void T09_Units_Move_Toward_Towers()
        {
            Game sid = new Game();
            sid.Run();
            Map var = new Map(sid);

            var job1 = Guid.NewGuid().ToString();
            Barbar v1 = new Barbar(0.9f, 0.7f,"Gobelin", var);
            Tower sido = new Tower(10f, 10f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            Assert.That(!v1.Position.IsInRange(v1.Position, sido.Position, v1.Range));

            while(!v1.Position.IsInRange(v1.Position, sido.Position, v1.Range))
            {
                v1.Position = v1.Position.Movement(v1.Position, sido.Position, 50, 0.02f, v1.Range);
            }

            Assert.That(v1.Position.IsInRange(sido.Position, v1.Position, sido.Range));
            Assert.That(var.BuildCount,Is.EqualTo(1));
        }

        [Test]
        public void T10_Tower_Acquire_Targets_Within_Range()
        {
            Game sid = new Game();
            sid.Run();
            Map var = new Map(sid);
            Tower sido = new Tower(0f, 0f, 250, 250, 30, 5, 1, 25.0f, 5, var,"Tower","tour");
            
            Assert.That(sido, Is.Not.Null);
            sido.AcquireTarget();
            Assert.That(sido.Target,Is.EqualTo(null));
            
            var job2 = Guid.NewGuid().ToString();

            for (float i = 0.2f; i < 1.5f; i += 0.1f)
            {
                Barbar v2 = new Barbar((27.7f + i), (25.7f + i),"Gobelin", var);
            }

            sido.AcquireTarget();

            Assert.That(sido.Target, Is.Null);

            Barbar v3 = new Barbar(12.7f, (13.7f), "Gobelin", var);
            sido.AcquireTarget();

            Assert.That(sido.Target, Is.EqualTo(v3));
        }

        [Test]
        public void T11_Waves_Create_The_Correct_Amout_of_Ennemies()
        {
            Game sid = new Game();
            sid.Run();
            Map map = new Map(sid);
            Assert.That(map.BarbCount, Is.EqualTo(0));

            map.Wave.Update();
            Assert.That(map.BarbCount, Is.EqualTo((4)));
            map.Wave.Update();
            Assert.That(map.BarbCount, Is.EqualTo((12)));
        }

        [Test]
        public void T12_Mages_Burn_Everything_In_Range()
        {
            Game sid = new Game();
            sid.Run();
            Map map = new Map(sid);
            Tower sido = new Tower(0f, 0f, 250, 250, 30, 5, 1, 25.0f, 5, map, "Tower", "tour");


            var job2 = Guid.NewGuid().ToString();
            Mage v2 = new Mage(12f , 10f,"Mage", map);
            v2.AcquireTarget();
            Assert.That(v2.EnemyTarget, Is.EqualTo(sido));

            v2.Update();
            Assert.That(!v2.Ignite.CD.IsUsable);
            Assert.That(sido.IsBurned);
            Assert.That(v2.EnemyTarget,Is.Null);
            Assert.That(v2.Ignite.DotBuildList.Count, Is.EqualTo(map.BuildCount));


            while (!v2.Ignite.CD.IsUsable)
            {
                v2.Update();
            }
            Assert.That(v2.EnemyTarget, Is.Null);

            Assert.That(v2.Ignite.CD.IsUsable);
            Assert.That(v2.Ignite.DotBuildList.Count, Is.EqualTo(1));
            v2.Update();

            Tower tido = new Tower(0f, 0f, 250, 250, 30, 5, 1, 25.0f, 5, map, "Tower", "tour");
            v2.Update();

            //Assert.That(v2.EnemyTarget, Is.EqualTo(tido));
            //Assert.That(tido.IsBurned);

        }

        [Test]
        public void T13_Land_Units_Cant_Attack_Flying_Units()
        {
            Map maps = new Map();
            var job1 = Guid.NewGuid().ToString();
            Barbar v3 = new Barbar(12.7f, (13.7f), "Gobelin", maps);
            Gargoyle v4 = new Gargoyle(12.7f, (13.7f), "Gargoyle", maps);
            Assert.That(v4.Job, Is.EqualTo("Gargoyle"));
            v3.Attack(v4);
            Assert.That(v4.Life, Is.EqualTo(150));
        }

        [Test]
        public void T14_Thunder_Tower_Paralyzes_Within_Constraints()
        {
            Game sid = new Game();
            sid.Run();
            Map map = new Map(sid);
            Thunder sido = new Thunder(0f, 0f, 250, 250, 30, 5, 1, 25.0f, 5, map, "Tower", "tour");

            var job2 = Guid.NewGuid().ToString();
            Mage v2 = new Mage(12f, 10f,"Mage", map);
            sido.AcquireTarget();
            Assert.That(sido.Target, Is.EqualTo(v2));
            sido.Paralyze();
            Assert.That(v2.IsParalysed);
            sido.Paralyze();
            Assert.That(sido.Target, Is.Null);
        }

        [Test]
        public void T15_All_Units_Join_Same_List()
        {
            Game sid = new Game();
            sid.Run();
            Map map = new Map(sid);
            Mage v2 = new Mage(12f, 10f,"Mage", map);
            Barbar v3 = new Barbar(12f, 10f, "Gobelin", map);
            Giant v4 = new Giant(12f, 10f, "Géant", map);
            Gargoyle v5 = new Gargoyle(12f, 10f, "Gargoyle", map);
            Assert.That(map.BarbCount, Is.EqualTo(4));
        }

        [Test]
        public void T16_Giants_Boulders_Hit_All_Targets_In_Range()
        {
            Map m = new Map();

            Assert.That(m, Is.Not.Null);
            var job1 = Guid.NewGuid().ToString();
            Barbar v3;
            v3 = new Barbar(12f, 10f,"Gobelin", m);

            for (int i = 0; i < 15;i++)
            {
                v3 = new Barbar(12f, 10f,"Gobelin", m);
            }

            Giant g1 = new Giant(12f, 10f, "Géant", m);
            g1.SetTarget(v3);
            g1.Attack(v3);

            for(int i = 0; i < m.BarList.Count;i++)
            {
                Assert.That(m.BarList[i].Life, Is.EqualTo(143));
            }
        }

        [Test]
        public void T17_Buildings_And_Units_Created_Correctly_AND_Removed_On_Death()
        {
            Game g = new Game();
            g.Run();
            Map m = new Map(g);

            m.GetGame.GetGrid[new Vector2i(-5,5)].SetName = "House";
            m.GetGame.GetGrid[new Vector2i(m.GetGame.GetWindow.GetView.X, m.GetGame.GetWindow.GetView.Y)].Building =
                new Tower(15f, 50f, 350, 350, 7, 2, 0, 30f, 2, m, "House", "Une habitation");

            Assert.That(m.GetGame.GetGrid[new Vector2i(-5, 5)].GetName, Is.EqualTo("House"));
            Assert.That(m.GetGame.GetGrid[new Vector2i(-5, 5)].GetName, Is.Not.Empty);
            Assert.That(m.BuildCount, Is.EqualTo(1));
            m.BuildList[0].Die();
            Assert.That(m.BuildCount, Is.EqualTo(0));
            Barbar v3 = new Barbar(12f, 10f,"Gobelin", m);
            Assert.That(m.BarbCount, Is.EqualTo(1));
            v3.Die();
            Assert.That(m.BarbCount, Is.EqualTo(0));
        }

        [Test]
        public void T18_SpellBook_Correctly_Created()
        {

            SpellBook s = new SpellBook();
            Assert.That(s.SpellList["Ignite"]["Nom"], Is.EqualTo("Embrasement"));
        }

        [Test]
        public void T19_Cooldown_Works_Correctly()
        {

            Cooldown s = new Cooldown(5);
            s.TimeStamp = (uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            while((uint)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds < s.TimeStamp + s.Cd)
            {
                s.Update();
            }
            s.Update();

            Assert.That(s.TimeStamp, Is.EqualTo(0));
        }
    }
}