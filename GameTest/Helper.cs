using Game;

namespace GameTest
{
    public class Helper
    {
        public const int ChildTagNumber1 = 1;
        public const int ChildTagNumber2 = 2;
        public const int ChildTagNumber3 = 3;
        public const int ChildTagNumber5 = 5;
        public const int ChildTagNumberNegative1 = -1;
        public const int ChildTagNumberNegative2 = -2;
        public const int ChildTagNumberNegative3 = -3;
        public const int ChildTagNumberNegative5 = -5;

        public static ChildrenLinkedList<int> CreateChildrenCircle(int numberChildren)
        {
            var circle = new ChildrenLinkedList<int>();
            for (var i = 1; i <= numberChildren; i++)
            {
                circle.Add(i);
            }
            return circle;
        }

        public static ChildrenLinkedList<int> CreateChildrenCircleNegativeNumbers(int numberChildren)
        {
            var circle = new ChildrenLinkedList<int>();
            for (var i = 1; i <= numberChildren; i++)
            {
                circle.Add(i*-1);
            }
            return circle;
        }
    }
}
