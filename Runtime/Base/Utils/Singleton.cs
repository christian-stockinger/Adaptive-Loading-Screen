
namespace AdaptiveLoadingScreen.Base
{
    public class Singleton<T> where T : class, new()
    {
        private static T instance = null;

        protected Singleton()
        {
        }

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }
    }
}


