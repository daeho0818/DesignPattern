using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    public class MyConnection
    {
        public MyConnection() { }
    }

    public class MyConnectionPool
    {
        private readonly Queue<MyConnection> pool = new Queue<MyConnection>();

        public MyConnection GetObject()
        {
            MyConnection obj;
            if (pool.Count > 0)
            {
                return pool.Dequeue();
            }
            else
            {
                return new MyConnection();
            }
        }

        public void ReleaseObject(MyConnection conn)
        {
            pool.Enqueue(conn);
            Debug.WriteLine($"Release: {conn.GetHashCode()}");
        }
    }

    class Clent
    {
        public static void HowToUse()
        {
            var myPool = new MyConnectionPool();
            MyConnection conn = myPool.GetObject();

            myPool.ReleaseObject(conn);

            MyConnection conn2 = myPool.GetObject();

            myPool.ReleaseObject(conn2);
        }
    }
}
