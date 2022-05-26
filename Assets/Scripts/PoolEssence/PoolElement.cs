namespace PoolEssence
{
    public class PoolElement<T> where T : class
    {
        public T Obj;
        public bool IsFree;
    }
}