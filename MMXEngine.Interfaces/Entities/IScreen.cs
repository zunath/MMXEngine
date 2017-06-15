namespace MMXEngine.Contracts.Entities
{
    public interface IScreen
    {
        void Initialize();
        void Update();
        void Draw();
        void Close();
    }
}
