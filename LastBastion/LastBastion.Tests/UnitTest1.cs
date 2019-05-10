using LastBastion;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void game_is_created_and_not_null()
        {
            Game sid = new Game();
            Assert.That(sid, Is.Not.Null);
            Map var = new Map(sid);

            Villager v1 = new Villager(10.9f, 11.2f, "Villageois", 150, 4, 3, false, 2, 1.5f);
            Villager v2 = new Villager(10.5f, 11.2f, "Villageois", 150, 4, 3, false, 2, 1.5f);
            v1.Move();
            Assert.That(v1.IsMoving, Is.True);

            var.AddVillager(v1);
            var.AddVillager(v2);
        }
    }
}