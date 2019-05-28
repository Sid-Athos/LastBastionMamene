using LastBastion;
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void T01_Game_Map_And_Castle_Are_created_and_not_null()
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
            Map var = new Map();

            Assert.That(var, Is.Not.Null);

            var job = Guid.NewGuid().ToString();
            Villager v1 = new Villager(10.9f, 11.2f, 0.1f,job, 150, 4, 3, false, 2, 1.5f, var);
            job = Guid.NewGuid().ToString();
            Villager v2 = new Villager(10.5f, 11.2f,0.1f,job, 150, 4, 3, false, 2, 1.5f, var);

            Assert.That(v1, Is.Not.Null);
            Assert.That(v2, Is.Not.Null);
        }

        [Test]
        public void T03_Units_Are_Created_And_Can_Join_Units_List()
        {
            Map var = new Map();
            Assert.That(var, Is.Not.Null);

            for(int i = 0; i < 4;i++)
            {

                var job1 = Guid.NewGuid().ToString();
                Barbar v1 = new Barbar(10.9f, 11.2f, 0.1f,job1, 150, 10, 3, false, 2, 1.5f, var);
                Assert.That(v1, Is.Not.Null);
            }
            Assert.That(var.BarbCount, Is.EqualTo(4));
        }

        [Test]
        public void T04_Units_Are_In_List_And_Attack_Correctly()
        {
            Map var = new Map();
            Assert.That(var, Is.Not.Null);
            

            var job1 = Guid.NewGuid().ToString();
            Barbar v1 = new Barbar(10.9f, 11.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
            var job2 = Guid.NewGuid().ToString();
            Barbar v2 = new Barbar(10.9f, 11.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);

             for (int i = 0; i < 6; i++)
            {
                v1.Attack(v2);
            }
            Assert.That(v2.Life, Is.EqualTo(108));

        }

        [Test]
        public void T05_Enemy_Units_Find_Tower_Wherever_They_Are()
        {
            Map var = new Map();
            Assert.That(var, Is.Not.Null);
            Tower sido = new Tower(-1000000f, -10000000f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            for (int i = 0; i < 6; i++)
            {
                var job1 = Guid.NewGuid().ToString();
                Barbar v1 = new Barbar(10.9f, 11.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
                v1.AcquireTarget();
                Assert.That(v1.EnemyTarget, Is.EqualTo(sido));
            }

            sido.Die();
            sido = new Tower(1000000f, 10000000f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            for (int i = 0; i < 6; i++)
            {
                var job1 = Guid.NewGuid().ToString();
                Barbar v1 = new Barbar(10.9f, 11.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
                v1.AcquireTarget();
                Assert.That(v1.EnemyTarget, Is.EqualTo(sido));
            }
        }

        [Test]
        public void T06_Towers_Switch_Targets_If_Enemy_Goes_Out_Of_Range()
        {
            Map var = new Map();
            Assert.That(var, Is.Not.Null);
            Tower sido = new Tower(10f, 12f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            
            var job1 = Guid.NewGuid().ToString();
            Barbar v1 = new Barbar(10.9f, 11.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
            v1.AcquireTarget();
            Assert.That(v1.EnemyTarget, Is.EqualTo(sido));
            Tower faaaaaar = new Tower(100f, 120f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            while (!v1.Position.IsInRange(v1.Position, faaaaaar.Position, v1.Range))
            {
                v1.Position = v1.Position.Movement(v1.Position, faaaaaar.Position, 10, v1.Speed, v1.Range);
            }
            sido.AcquireTarget();
            Assert.That(sido.Target, Is.EqualTo(null));
            Barbar v2 = new Barbar(10.9f, 11.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
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

        [Test]
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

        }

        [Test]
        public void T08_Projectiles_Created_Equal_To_Tower_Plus_Archar_Count_On_Attack()
        {
            Map var = new Map();

            Tower sido = new Tower(0.5f, 10.5f, 500, 500, 15, 5, 5, 10f, 1, var, "Tour", "Du rohan");
            var job1 = Guid.NewGuid().ToString();
            Barbar v1 = new Barbar(10.9f, 11.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
            sido.AcquireTarget();
            Assert.That(sido.ShowArchers, Is.EqualTo(2));
            Assert.That(sido.TimeSt, Is.EqualTo(0));

            Assert.That(sido.Target, Is.EqualTo(v1));
            sido.Attack(sido.Target);
            Assert.That(sido.ProjList.Count, Is.EqualTo(3));

        }

        [Test]
        public void T09_Units_Move_Toward_Towers()
        {
            Map var = new Map();

            var job1 = Guid.NewGuid().ToString();
            Barbar v1 = new Barbar(0.9f, 0.7f, 0.2f, job1, 150, 10, 3, false, 2, 5.0f, var);
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
            Map var = new Map();
            Tower sido = new Tower(0f, 0f, 250, 250, 30, 5, 1, 25.0f, 5, var,"Tower","tour");
            
            Assert.That(sido, Is.Not.Null);
            sido.AcquireTarget();
            Assert.That(sido.Target,Is.EqualTo(null));
            
            var job2 = Guid.NewGuid().ToString();

            for (float i = 0.2f; i < 1.5f; i += 0.1f)
            {
                Barbar v2 = new Barbar((27.7f + i), (25.7f + i), 0.1f, job2, 150, 10, 3, false, 2, 1.5f, var);
            }

            sido.AcquireTarget();

            Assert.That(sido.Target, Is.Null);

            Barbar v3 = new Barbar(12.7f, (13.7f), 0.1f, job2, 150, 10, 3, false, 2, 1.5f, var);
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
            Assert.That(map.BarbCount, Is.EqualTo((8)));
        }

        [Test]
        public void T12_Mages_Burn_Everything_In_Range()
        {
            Map var = new Map();
            Tower sido = new Tower(0f, 0f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");
            Tower tido = new Tower(0f, 0f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");


            var job2 = Guid.NewGuid().ToString();
            Mage v2 = new Mage(12f , 10f, 30f, job2, 150, 10, 3, false, 2, 5f, var);
            v2.AcquireTarget();
            Assert.That(v2.EnemyTarget, Is.EqualTo(sido));

            v2.Ignite();
            Assert.That(sido.IsBurned);
            Assert.That(v2.BurList.Count, Is.EqualTo(1));
            v2.Ignite();
            Assert.That(v2.BurList.Count, Is.EqualTo(2));
            v2.Ignite();
            Assert.That(v2.BurList.Count, Is.EqualTo(2));

            Assert.That(v2.EnemyTarget, Is.EqualTo(null));
        }

        [Test]
        public void T13_Land_Units_Cant_Attack_Flying_Units()
        {
            Map maps = new Map();
            var job1 = Guid.NewGuid().ToString();
            Barbar v3 = new Barbar(12.7f, (13.7f), 0.1f, job1, 150, 10, 3, false, 2, 1.5f, maps);
            Gargoyle v4 = new Gargoyle(12.7f, (13.7f), 0.1f, "Gargoyle", 150, 10, 3, false, 2, 1.5f, maps);
            Assert.That(v4.Job, Is.EqualTo("Gargoyle"));
            v3.Attack(v4);
            Assert.That(v4.Life, Is.EqualTo(150));
        }

        [Test]
        public void T14_Thunder_Tower_Paralyzes_Within_Constraints()
        {
            Map var = new Map();
            Thunder sido = new Thunder(0f, 0f, 250, 250, 30, 5, 1, 25.0f, 5, var, "Tower", "tour");

            var job2 = Guid.NewGuid().ToString();
            Mage v2 = new Mage(12f, 10f, 30f, job2, 150, 10, 3, false, 2, 5f, var);
            sido.AcquireTarget();
            Assert.That(sido.Target, Is.EqualTo(v2));
            sido.Paralyze();
            Assert.That(v2.IsParalysed);
            sido.Paralyze();
            Assert.That(sido.Target, Is.Null);
        }

        [Test]
        public void T15_Check()
        {

        }
    }
}