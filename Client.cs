namespace RentRoom
{
    public class Client
    {
        public int ThreadId {get; set;}
        public void DoSomething() {
            RoomPool pool = RoomPool.getInstance();
            pool.PoolStatus(ThreadId);

            Room r1 = pool.RentRoom();
            Room r2 = pool.RentRoom();
            pool.PoolStatus(ThreadId);

            pool.CancelReservation(r1);
            pool.PoolStatus(ThreadId);

            Room r3 = pool.RentRoom();
            pool.PoolStatus(ThreadId);
            
            pool.CancelReservation(r2);
            pool.PoolStatus(ThreadId);
        }
    }
}