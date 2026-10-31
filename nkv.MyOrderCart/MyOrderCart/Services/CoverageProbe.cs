namespace MyOrderCart.Services
{
    public static class CoverageProbe
    {
        public static string Grade(int score)
        {
            if (score >= 90)
            {
                return "A";
            }
            if (score >= 80)
            {
                return "B";
            }
            if (score >= 70)
            {
                return "C";
            }
            if (score >= 60)
            {
                return "D";
            }
            return "F";
        }

        public static int Total(int[] values)
        {
            var total = 0;
            foreach (var value in values)
            {
                if (value > 0)
                {
                    total += value;
                }
            }
            return total;
        }
    }
}
