using System.Linq;
using NUnit.Framework;
namespace GameTest
{
	[TestFixture ()]
	public class CreateCircleTest
	{
		[SetUp]
		public void Init()
		{
		}

		[Test()]
		public void ChildrenCircle_Count()
		{
		    var circle = Helper.CreateChildrenCircle(3);
			Assert.AreEqual (circle.Count, 3);
		}

		[Test() ]
		public void ChildrenCircle_FirstInCircle()
		{
            var circle = Helper.CreateChildrenCircle(3);
			Assert.AreEqual(circle.First.NumberTag, Helper.ChildTagNumber1);
		}

		[Test()]
		public void ChildrenCircle_LastInCircle()
		{
            var circle = Helper.CreateChildrenCircle(3);
			Assert.AreEqual (Helper.ChildTagNumber3, circle.Last.NumberTag);
		}

		[Test()]
		public void ChildrenCircle_1stChild_ClockwiseFriend()
		{
            var circle = Helper.CreateChildrenCircle(3);
			Assert.AreEqual (Helper.ChildTagNumber2, circle.First.Next.NumberTag );
		}

		[Test()]
		public void ChildrenCircle_1stChild_AntiClockwiseFriend()
		{
            var circle = Helper.CreateChildrenCircle(3);
			Assert.AreEqual (Helper.ChildTagNumber3, circle.First.Previous.NumberTag );
		}

		[Test()]
		public void ChildrenCircle_2ndChild_ClockwiseFriend()
		{
            var circle = Helper.CreateChildrenCircle(3);
			Assert.AreEqual (Helper.ChildTagNumber3, circle.First.Next.Next.NumberTag );
		}

		[Test()]
		public void ChildrenCircle_2ndChild_AntiClockwiseFriend()
		{
            var circle = Helper.CreateChildrenCircle(3);
			Assert.AreEqual (Helper.ChildTagNumber1, circle.First.Next.Previous.NumberTag );
		}

		[Test()]
		public void ChildrenCircle_3rdChild_ClockwiseFriend()
		{
            var circle = Helper.CreateChildrenCircle(3);
			Assert.AreEqual (Helper.ChildTagNumber1, circle.First.Next.Next.Next.NumberTag);
		}

		[Test()]
		public void ChildrenCircle_3rdChild_AntiClockwiseFriend()
		{
            var circle = Helper.CreateChildrenCircle(3);
			Assert.AreEqual (Helper.ChildTagNumber2, circle.First.Next.Next.Previous.NumberTag);
		}

		[Test()]
		public void ChildrenCircle_FindChild_TagNumber3()
		{
            var circle = Helper.CreateChildrenCircle(3);
			var child = circle.Find (Helper.ChildTagNumber3);
			Assert.AreEqual (Helper.ChildTagNumber3, child.NumberTag);
		}

        [Test()]
        public void ChildrenCircle_FindChild_TagNumber2()
        {
            var circle = Helper.CreateChildrenCircle(3);
            var child = circle.Find(Helper.ChildTagNumber2);
            Assert.AreEqual(Helper.ChildTagNumber2, child.NumberTag);
        }

        [Test()]
        public void ChildrenCircle_FindChild_TagNumber1()
        {
            var circle = Helper.CreateChildrenCircle(1);
            var child = circle.Find(Helper.ChildTagNumber1);
            Assert.AreEqual(Helper.ChildTagNumber1, child.NumberTag);
        }

        [Test()]
        public void ChildrenCircle_FindNextChildToExitCircle_kOffset2()
        {
            var circle = Helper.CreateChildrenCircle(3);
            var child = circle.FindNextChildToExitCircle(2);
            Assert.AreEqual(Helper.ChildTagNumber2, child.NumberTag);
        }

        [Test()]
        public void ChildrenCircle_FindNextChildToExitCircle_kOffset4()
        {
            var circle = Helper.CreateChildrenCircle(3);
            var child = circle.FindNextChildToExitCircle(4);
            Assert.AreEqual(Helper.ChildTagNumber1, child.NumberTag);
        }

        [Test()]
        public void ChildrenCircle_FindNextChildToExitCircle_kOffset9()
        {
            var circle = Helper.CreateChildrenCircle(3);
            var child = circle.FindNextChildToExitCircle(9);
            Assert.AreEqual(Helper.ChildTagNumber3, child.NumberTag);
        }

        [Test()]
        public void ChildrenCircle_Empty_FindNextChildToExitCircle_kOffset9()
        {
            var circle = Helper.CreateChildrenCircle(0);
            var child = circle.FindNextChildToExitCircle(9);
            Assert.AreEqual(null, child);
        }

        [Test()]
        public void ChildrenCircle_RemoveChild_TagNumber2()
        {
            var circle = Helper.CreateChildrenCircle(3);
            bool removed = circle.Remove(Helper.ChildTagNumber2);
            Assert.IsTrue(removed);
        }

        [Test()]
        public void ChildrenCircle_RemoveChild_TagNumberNegative1()
        {
            var circle = Helper.CreateChildrenCircle(3);
            var removed = circle.Remove(Helper.ChildTagNumberNegative1);
            Assert.IsFalse(removed);
        }

        [Test()]
        public void ChildrenCircle_FindWinnerCount_10Children_kOffset4()
        {
            var circle = Helper.CreateChildrenCircle(10);
            var child = circle.FindWinner(4);
            Assert.AreEqual(10, child.Count());
        }

        [Test()]
        public void ChildrenCircle_FindWinner_3Children_kOffset4()
        {
            var circle = Helper.CreateChildrenCircle(3);
            var child = circle.FindWinner(4);
            Assert.AreEqual(Helper.ChildTagNumber2, child.Last());
        }

        [Test()]
        public void ChildrenCircle_FindWinner_10Children_kOffset4()
        {
            var circle = Helper.CreateChildrenCircle(10);
            var child = circle.FindWinner(4);
            Assert.AreEqual(Helper.ChildTagNumber5, child.Last());
        }

        [Test()]
        public void ChildrenCircle_FindWinner_1Children_kOffset1()
        {
            var circle = Helper.CreateChildrenCircle(1);
            var child = circle.FindWinner(1);
            Assert.AreEqual(0, child.Count());
        }

        [Test()]
        public void ChildrenCircle_FindWinner_1Children_kOffset4()
        {
            var circle = Helper.CreateChildrenCircle(1);
            var child = circle.FindWinner(4);
            Assert.AreEqual(0, child.Count());
        }

        [Test()]
        public void ChildrenCircle_FindWinner_0Children_kOffset1()
        {
            var circle = Helper.CreateChildrenCircle(0);
            var child = circle.FindWinner(1);
            Assert.AreEqual(0, child.Count());
        }

        [Test()]
        public void ChildrenCircle_FindWinner_3Children_kOffsetNegative1()
        {
            var circle = Helper.CreateChildrenCircle(3);
            var child = circle.FindWinner(Helper.ChildTagNumberNegative1);
            Assert.AreEqual(0, child.Count());
        }

        [Test()]
        public void ChildrenCircle_FindWinner_Negative10Children_kOffset0()
        {
            var circle = Helper.CreateChildrenCircle(-10);
            var child = circle.FindWinner(0);
            Assert.AreEqual(0, child.Count());
        }

        [Test()]
        public void ChildrenCircleNegativeNumbers_FindWinner_10Children_kOffset4()
        {
            var circle = Helper.CreateChildrenCircleNegativeNumbers(10);
            var child = circle.FindWinner(4);
            Assert.AreEqual(Helper.ChildTagNumberNegative5, child.Last());
        }
	}
}

