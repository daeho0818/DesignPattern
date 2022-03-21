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
        private readonly ConcurrentBag<MyConnection> pool = new ConcurrentBag<MyConnection>();

        // pool에 obj가 있다면 반환, 없다면 생성하여 반환하는 함수
        public MyConnection GetObject()
        {
            MyConnection obj;
            if (pool.TryTake(out obj))
            {
                return obj;
            }
            else
            {
                return new MyConnection();
            }
        }

        // 사용이 끝난 obj를 pool에 돌려주는 함수
        public void ReleaseObject(MyConnection conn)
        {
            pool.Add(conn);
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
