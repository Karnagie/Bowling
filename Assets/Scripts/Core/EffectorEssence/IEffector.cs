using System.Threading.Tasks;

namespace Core.EffectorEssence
{
    public interface IEffector
    {
        void Show(float speed);
        void Hide(float speed);
        void StopAll();
        Task HideAsync(float speed);
    }
}