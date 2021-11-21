namespace BagKata
{
    public interface IBackpack 
    {
        void Add(string anyitem);
        bool IsFull();
    }
}