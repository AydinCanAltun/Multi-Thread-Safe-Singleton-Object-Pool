namespace RentRoom
{
    public interface IRoomPool
    {
        Room RentRoom();
        void CancelReservation(Room room);
        void PoolStatus(int threadId);
    }
}