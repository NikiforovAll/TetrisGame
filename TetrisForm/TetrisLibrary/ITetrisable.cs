namespace Tetris
{
    public interface ITetrisable
    {
        void Sync(SimpleCube sc);
        void Render(SimpleCube sc);
        ITetrisable Create(SimpleCube sc);
        void Delete();
    }
}
