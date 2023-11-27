using Leopotam.EcsLite;

namespace RunnerECS 
{
    public static class EcsWorldExtentions
    {
        public static EcsFilter GetFilterAndPool<T>(this EcsWorld ecsWorld, out EcsPool<T> pool) where T : struct
        {
            pool = ecsWorld.GetPool<T>();
            return ecsWorld.Filter<T>().End();
        }

        public static EcsFilter GetFilterAndPools<T, F>(this EcsWorld ecsWorld, out EcsPool<T> pool, out EcsPool<F> pool2) 
            where T : struct 
            where F : struct
        {
            pool = ecsWorld.GetPool<T>();
            pool2 = ecsWorld.GetPool<F>();
            return ecsWorld.Filter<T>().Inc<F>().End();
        }   

        public static EcsFilter GetFilterAndPools<T, F, V>(this EcsWorld ecsWorld, out EcsPool<T> pool, out EcsPool<F> pool2, out EcsPool<V> pool3) 
            where T : struct 
            where F : struct
            where V : struct
        {
            pool = ecsWorld.GetPool<T>();
            pool2 = ecsWorld.GetPool<F>();
            pool3 = ecsWorld.GetPool<V>();
            return ecsWorld.Filter<T>().Inc<F>().Inc<V>().End();
        }       
    }

}
