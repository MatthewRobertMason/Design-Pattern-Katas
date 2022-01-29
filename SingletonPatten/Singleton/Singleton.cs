namespace SingletonPatten
{
    /// <summary>
    /// A Singleton class to mess around with, none of this should be considered "perfect" code.
    /// </summary>
    /// <typeparam name="T">The typeof Singleton.</typeparam>
    public sealed class Singleton<T>
    {
        internal static readonly Lazy<Singleton<T>> _instance = new Lazy<Singleton<T>>(() => new Singleton<T>());
        private T? _value;

        public static Singleton<T> Instance
        {
            get
            {
                Console.WriteLine("Get Instance");
                return _instance.Value;
            }
        }

        public T? Value 
        { 
            get 
            {
                T? temp = Instance._value;
                Console.WriteLine($"Get Value: {temp}");
                return temp; 
            } 
            set
            {
                Instance._value = value;
                Console.WriteLine($"Set Value: {value}");
            }
        }

        private Singleton()
        {
            Console.WriteLine("Constructor");
        }
    }
}