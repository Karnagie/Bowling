using System.Collections.Generic;
using System.Linq;
using BreakableObjects.BallEssence;
using UnityEngine;

namespace PoolEssence
{
    public class PlayerBallPool : IPool<Ball>
    {
        private List<PoolElement<Ball>> _objects;
        private Ball _prefab;

        public PlayerBallPool(Ball prefab)
        {
            _objects = new List<PoolElement<Ball>>();
            _prefab = prefab;
        }

        public int Count => BallCount();

        private int BallCount()
        {
            int count = 0;
            foreach (var element in _objects)
            {
                if (!element.IsFree) count++;
            }

            return count;
        }

        public Ball Get()
        {
            return GetInternal(null, Vector3.zero);
        }
        
        public Ball Get(Transform parent, Vector3 position)
        {
            return GetInternal(parent, position);
        }

        public void Return(Ball obj)
        {
            PoolElement<Ball> poolElement = _objects.First(o => o.Obj == obj);
            poolElement.Obj.gameObject.SetActive(false);
            poolElement.IsFree = true;
        }

        public Ball[] GetAllObjects()
        {
            List<Ball> balls = new List<Ball>();
            
            foreach (var element in _objects)
            {
                if(!element.IsFree)balls.Add(element.Obj);
            }

            return balls.ToArray();
        }

        private Ball GetInternal(Transform parent, Vector3 position)
        {
            foreach (var poolObject in _objects)
            {
                if (poolObject.IsFree)
                {
                    poolObject.Obj.gameObject.SetActive(true);
                    poolObject.Obj.transform.SetParent(parent);
                    poolObject.Obj.transform.position = position;
                    poolObject.IsFree = false;
                    poolObject.Obj.Init(this);
                    return poolObject.Obj;
                }
            }
            GameObject g = MonoBehaviour.Instantiate(_prefab.gameObject, parent);
            g.transform.position = position;
            
            PoolElement<Ball> newElement = new PoolElement<Ball>();
            newElement.Obj = g.GetComponent<Ball>();
            newElement.Obj.gameObject.SetActive(true);
            newElement.IsFree = false;
            newElement.Obj.Init(this);
            _objects.Add(newElement);
            
            return g.GetComponent<Ball>();
        }
    }
}