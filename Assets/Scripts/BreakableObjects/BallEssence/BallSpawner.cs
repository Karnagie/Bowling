using System;
using System.Threading.Tasks;
using GameEssence;
using PoolEssence;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BreakableObjects.BallEssence
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private Ball _prefab;

        private Transform _parent;
        private PlayerBallPool _pool;

        public int Count => _pool.Count;
        
        public void Init(Transform parent)
        {
            _parent = parent;
            _pool = new PlayerBallPool(_prefab);
        }

        public Ball Spawn()
        {
            Vector3 random = new Vector3(Random.Range(0f, 3f), 0, Random.Range(0f, 3f));
            return _pool.Get(_parent, transform.position+random);
        }
        
        public Ball[] Spawn(int count)
        {
            Ball[] balls = new Ball[count];
            Vector3 random;
            
            for(int i = 0;  i < balls.Length; i++)
            {
               random = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
               balls[i] = _pool.Get(_parent, transform.position+random);
            }

            return balls;
        }

        public async void AddInBall(WinBall ball)
        {
            try
            {
                foreach (var obj in _pool.GetAllObjects())
                {
                    obj.TurnOffPhys();
                    obj.MoveTo(ball);
                    await Task.Delay(10);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}