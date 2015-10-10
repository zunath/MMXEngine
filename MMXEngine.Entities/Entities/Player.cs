using System;
using Artemis;
using MMXEngine.Interfaces.Entities;

namespace MMXEngine.ECS.Entities
{
    public class Player : IPlayer
    {
        public Player(IEnemy enemy, EntityWorld world)
        {
            Console.WriteLine(("Enemy val: " + enemy.TestValue));

        }

        public void test()
        {
        }
    }
}
