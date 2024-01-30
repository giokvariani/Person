namespace BasePerson.Application.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static IReadOnlyCollection<T> AsReadOnlyList<T>(this IEnumerable<T> enumerable) => (enumerable as List<T> ?? enumerable.ToList()).AsReadOnly();
    }
}
