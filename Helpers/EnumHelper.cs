namespace GameOfLife.Helpers
{
    public static class EnumHelper
    {
        public static T? GetRandomEnumValue<T>()
        {
            var values = Enum.GetValues(typeof(T));
            return (T?)values.GetValue(Random.Shared.Next(values.Length));
        }
    }
}
