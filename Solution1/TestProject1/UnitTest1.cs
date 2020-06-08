using ConsoleApp1;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void A_dead_Cell_stays_dead_when_has_less_than_2_neighbour([Values(0, 1)] int neighbours)
        {
            var cell = Conways.Execute(Cell.Dead, neighbours);

            Assert.AreEqual(Cell.Dead, cell);
        }

        [Test]
        public void A_live_Cell_dies_when_has_less_than_2_neighbour_by_under_population([Values(0, 1)] int neighbours)
        {
            var cell = Conways.Execute(Cell.Alive, neighbours);

            Assert.AreEqual(Cell.Dead, cell);
        }

        [Test]
        public void A_live_Cell_dies_when_has_more_than_3_neighbour([Values(4, 5, 6, 7, 8)] int neighbours)
        {
            var cell = Conways.Execute(Cell.Alive, neighbours);

            Assert.AreEqual(Cell.Dead, cell);
        }

        [Test]
        public void A_dead_Cell_stays_dead_when_has_more_than_3_neighbour([Values(4, 5, 6, 7, 8)] int neighbours)
        {
            var cell = Conways.Execute(Cell.Dead, neighbours);

            Assert.AreEqual(Cell.Dead, cell);
        }

        [Test]
        public void A_live_Cell_stays_alive_when_has_2_or_3_neighbour([Values(2, 3)] int neighbours)
        {
            var cell = Conways.Execute(Cell.Alive, neighbours);

            Assert.AreEqual(Cell.Alive, cell);
        }

        [Test]
        public void A_dead_Cell_stays_dead_when_has_2_neighbour()
        {
            var cell = Conways.Execute(Cell.Dead, 2);

            Assert.AreEqual(Cell.Dead, cell);
        }

        [Test]
        public void A_dead_Cell_lives_when_has_3_neighbour()
        {
            var cell = Conways.Execute(Cell.Dead, 3);

            Assert.AreEqual(Cell.Alive, cell);
        }

    }
}
