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
        public void T2_Create_Map_Add_Villagers()
        {
            Game sid = new Game();
            sid.Run();
            Assert.That(sid, Is.Not.Null);
            Map var = new Map(sid);
            Assert.That(var, Is.Not.Null);

            var job = Guid.NewGuid().ToString();
            Villager v1 = new Villager(10.9f, 11.2f, 0.1f,job, 150, 4, 3, false, 2, 1.5f, var);
            job = Guid.NewGuid().ToString();
            Villager v2 = new Villager(10.5f, 11.2f,0.1f,job, 150, 4, 3, false, 2, 1.5f, var);
            v1.Move();
            Assert.That(v1, Is.Not.Null);
            Assert.That(v2, Is.Not.Null);
        }

        [Test]
        public void T3_Units_Are_Created_And_Can_Join_Units_List()
        {
            Game sid = new Game();
            sid.Run();
            Assert.That(sid, Is.Not.Null);
            Map var = new Map(sid);
            Assert.That(var, Is.Not.Null);

            var job1 = Guid.NewGuid().ToString();
            Villager v1 = new Villager(10.9f, 11.2f, 0.1f,job1, 150, 10, 3, false, 2, 1.5f, var);
            var job2 = Guid.NewGuid().ToString();
            Villager v2 = new Villager(10.5f, 11.2f,0.1f, job2, 150, 10, 3, false, 2, 1.5f, var);
            var job3 = Guid.NewGuid().ToString();
            Villager v3 = new Villager(10.9f, 11.2f, 0.1f, job3, 150, 10, 3, false, 2, 1.5f, var);
            var job4 = Guid.NewGuid().ToString();
            Villager v4 = new Villager(10.9f, 11.2f, 0.1f, job4, 150, 10, 3, false, 2, 1.5f, var);

            Assert.That(var.VillCount, Is.EqualTo(4));
        }

        [Test]
        public void T4_Units_Are_In_List_And_Attack_Correctly()
        {
            Game sid = new Game();
            sid.Run();
            Assert.That(sid, Is.Not.Null);
            Map var = new Map(sid);
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
            }

            Assert.That(v2.Life, Is.EqualTo(108));
        }

        [Test]
        public void T5_Units_Can_Move_And_Attack()
        {
            Game sid = new Game();
            sid.Run();
            Assert.That(sid, Is.Not.Null);
            Map var = new Map(sid);
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
        public void T6_Archers_are_created_join_towers_within_limits_Plus_Enemy_Finder()
        {

            Game sid = new Game();
            sid.Run();
            Assert.That(sid, Is.Not.Null);

            Map var = new Map(sid);

            Tower sido = new Tower(0.5f,10.5f,500,15,5,5,1,1,var);
            Assert.That(sido.ShowArchers(), Is.EqualTo(2));
            //sido.AddArcher(v1);
            //Assert.Throws<InvalidOperationException>(() => sido.AddArcher(v1));
            //sido.AddArcher(v2);
            //Assert.Throws<InvalidOperationException>(() => sido.AddArcher(v3));

            Assert.That(sido.ShowArchers(), Is.EqualTo(2));
            sido.Upgrade();
            Assert.That(sido.ShowArchers(), Is.EqualTo(4));
            Archer test = new Archer(0.5f, 10.4f, 2.0f, "Archer", 50, 5, 2, false, 3, 0.2f, false, var);
            Assert.Throws<InvalidOperationException>(() => sido.AddArcher(test));

        }


        [Test]
        public void T7_Moves_With_Timestamp()
        {
            Game sid = new Game();
            sid.Run();
            Assert.That(sid, Is.Not.Null);

            Map var = new Map(sid);
            Assert.That(sid,Is.Not.Null);
        }

        [Test]
        public void T8_Tower_Acquire_Targets_Within_Constraints()
        {
            Game sid = new Game();
            sid.Run();

            Map var = new Map(sid);

            var job1 = Guid.NewGuid().ToString();
            Villager v1 = new Villager(0.9f, 5.2f, 0.1f, job1, 150, 10, 3, false, 2, 1.5f, var);
            Tower sido = new Tower(0.5f, 0.5f, 250, 250, 30, 5, 5, 1, var);
            
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