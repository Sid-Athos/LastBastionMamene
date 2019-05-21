using LastBastion;
using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void T1_Game_and_Map_Are_created_and_not_null()
        {
            Game sid = new Game();
            sid.Run();
            Assert.That(sid, Is.Not.Null);
            Map var = new Map(sid);
            Assert.That(var, Is.Not.Null);
        }

        [Test]
        public void T2_Create_Map_Create_Villagers()
        {
            Map var = new Map();

            Assert.That(var, Is.Not.Null);
            Assert.That(var.VillCount, Is.EqualTo(0));

            var job = Guid.NewGuid().ToString();
            Villager v1 = new Villager(10.9f, 11.2f, 0.1f,job, 150, 4, 3, false, 2, 1.5f, var);
            job = Guid.NewGuid().ToString();
            Villager v2 = new Villager(10.5f, 11.2f,0.1f,job, 150, 4, 3, false, 2, 1.5f, var);

            Assert.That(v1, Is.Not.Null);
            Assert.That(v2, Is.Not.Null);
        }

        [Test]
        public void T3_Units_Are_Created_And_Can_Join_Units_List()
        {
            Map var = new Map();
            Assert.That(var, Is.Not.Null);

            for(int i = 0; i < 4;i++)
            {

                var job1 = Guid.NewGuid().ToString();
                Villager v1 = new Villager(10.9f, 11.2f, 0.1f,job1, 150, 10, 3, false, 2, 1.5f, var);
                Assert.That(v1, Is.Not.Null);

            }

            Assert.That(var.VillCount, Is.EqualTo(4));
        }

        [Test]
        public void T4_Units_Are_In_List_And_Attack_Correctly()
        {
            Map var = new Map();
            Assert.That(var, Is.Not.Null);


            var job1 = Guid.NewGuid().ToString();
            Villager v1 = new Villager(10.9f, 11.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
            var job2 = Guid.NewGuid().ToString();
            Villager v2 = new Villager(10.5f, 11.2f, 0.1f, job2, 150, 10, 3, false, 2, 1.5f, var);
            var job3 = Guid.NewGuid().ToString();
            Villager v3 = new Villager(10.9f, 11.2f, 0.1f, job3, 150, 10, 3, false, 2, 1.5f, var);
            var job4 = Guid.NewGuid().ToString();
            Villager v4 = new Villager(10.9f, 11.2f, 0.1f, job4, 150, 10, 3, false, 2, 1.5f, var);


            Assert.That(var.VillCount, Is.EqualTo(4));

             for (int i = 0; i < 6; i++)
            {
                v1.Attack(v2);
                v3.Attack(v4);
            }

            Assert.That(v2.Life, Is.EqualTo(108));
            Assert.That(v4.Life, Is.EqualTo(108));

        }

        [Test]
        public void T5_Units_Can_Attack()
        {
            Map var = new Map();
            Assert.That(var, Is.Not.Null);
            var job1 = Guid.NewGuid().ToString();
            Villager v1 = new Villager(10.9f, 11.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
            var job2 = Guid.NewGuid().ToString();
            Villager v2 = new Villager(10.5f, 11.2f, 0.1f, job2, 150, 10, 3, false, 2, 1.5f, var);
            var job3 = Guid.NewGuid().ToString();
            Villager v3 = new Villager(10.9f, 11.2f, 0.1f, job3, 150, 10, 3, false, 2, 1.5f, var);
            var job4 = Guid.NewGuid().ToString();
            Villager v4 = new Villager(10.9f, 11.2f, 0.1f, job4, 150, 10, 3, false, 2, 1.5f, var);

            for (int i = 0; i < 6; i++)
            {
                v1.Attack(v2);
            }

            Assert.That(v2.Life, Is.EqualTo(108));
        }

        [Test]
        public void T6_Archers_are_created_join_towers_within_limits_Plus_Tower_Upgrade()
        {
            Map var = new Map();

            Tower sido = new Tower(0.5f,10.5f,500,15,5,5,1,1,var);
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
        public void T7_Units_Move_Toward_Towers()
        {
            Map var = new Map();

            var job1 = Guid.NewGuid().ToString();
            Barbar v1 = new Barbar(0.9f, 5.2f, 0.2f, job1, 150, 10, 3, false, 2, 0.2f, var);
            Tower v3 = new Tower(13.7f, 24.8f, 150, 150, 10, 3, 2, 0, var);

            while(!v1.Position.IsInRange(v1.Position,v3.Position,1.5f))
            {
                    v1.Position = v1.Position.Movement(v1.Position, v3.Position, 0, 1.0f, 2.0f);
                    bool check = v1.Position.IsInRange(v1.Position, v3.Position, 1.5f);
            }

            Assert.That(v1.Position.IsInRange(v1.Position, v3.Position, v1.Range));
        }

        [Test]
        public void T8_Tower_Acquire_Targets_Within_Constraints()
        {
            Map var = new Map();
            var job1 = Guid.NewGuid().ToString();
            Villager v1 = new Villager(0.9f, 5.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
            Tower sido = new Tower(0.5f, 0.5f, 250, 250, 30, 5, 5, 1, var);

            Assert.That(v1, Is.Not.Null);
            Assert.That(sido, Is.Not.Null);

            Assert.Throws<InvalidOperationException>(() => sido.AcquireTarget());
            
            var job2 = Guid.NewGuid().ToString();

            for (float i = 0.2f; i < 1.5f; i += 0.1f)
            {
                Barbar v2 = new Barbar((0.7f + i), (0.7f + i), 0.1f, job2, 150, 10, 3, false, 2, 1.5f, var);
            }

            sido.AcquireTarget();

            Assert.That(sido.Target, Is.Null);
            Barbar v3 = new Barbar(0.7f, (0.7f), 0.1f, job2, 150, 10, 3, false, 2, 1.5f, var);
            sido.AcquireTarget();
            Assert.That(sido.Target, Is.EqualTo(v3));
        }
    }
}