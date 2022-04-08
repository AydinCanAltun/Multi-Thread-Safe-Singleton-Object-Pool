using System;
using System.Collections.Generic;
using System.Linq;

namespace RentRoom
{
    public class RoomPool : IRoomPool
    {
        private int POOL_SIZE = 10;
        private static object instanceLock = new object();
        private volatile static RoomPool instance = null;

        private static List<Room> availableRoom = new List<Room>();
        private static List<Room> rentedRoom = new List<Room>();

        private RoomPool(){
            initPool();
        }

        private void initPool(){
            for(int i=0; i<POOL_SIZE; i++){
                Room room = new Room();
                room.RoomNumber = i + 1;
                room.IsOceanView = i % 2 == 0;
                availableRoom.Add(room);
            }
        }

        public static RoomPool getInstance() {
            if(instance == null){
                lock(RoomPool.instanceLock){
                    if(instance == null){
                        instance = new RoomPool();
                    }
                }
            }
            return instance;
        }

        public Room RentRoom(){
            lock(RoomPool.availableRoom){
                if(availableRoom.Count != 0){
                    Room room = availableRoom.ElementAt(0);
                    rentedRoom.Add(room);
                    availableRoom.Remove(room);
                    return room;
                }
                return null;
            }
        }

        public void CancelReservation(Room room) {
            if(room != null) {
                lock(RoomPool.availableRoom){
                    availableRoom.Add(room);
                    rentedRoom.Remove(room);
                }
            }
            
        }

        public void PoolStatus(int threadId){
            Console.WriteLine(string.Format("Thread {0} -> Available Rooms: {1}, Rented Rooms: {2}", threadId, availableRoom.Count, rentedRoom.Count));
        }

    }
}