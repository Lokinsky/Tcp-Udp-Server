using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using udp_server.Models;

namespace udp_server.DataStructures
{
    class Connections : IEnumerable<Connection>
    {
        int pointer = 0;
        private List<Connection> connections;
        private static Connections instance = null;
        private static readonly object padlock = new object();
        public int Count { get; set; }
        private Connections()
        {
            connections = new List<Connection>();
        }
        public static Connections Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Connections();
                    }
                    return instance;
                }
            }
        }

        public void Add(Connection connection)
        {
            if (connection != null)
            {
                connections.Add(connection);
                Count = connections.Count;
            }
            else
            {
                Console.WriteLine("Error while putting channel in the list");
            }
        }

        public void Remove(int index)
        {
            if (index <= connections.Count - 1)
            {
                connections.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Error while removing at index: " + index);
            }
        }
        public void Remove(Connection connection)
        {
            if (connection != null)
            {
                if (connections.Exists(e => e.IP == connection.IP))
                {
                    connections.Remove(connection);
                }
                else
                {
                    Console.WriteLine("Warning: given element doesn`t exists.");
                }
            }
            else
            {
                Console.WriteLine("Error while removing: nullPointerException");
            }
        }
        public Connection Get(int index)
        {
            if (index <= connections.Count - 1)
            {
                return connections[index];
            }
            else
            {
                Console.WriteLine("Error while removing at index: " + index);
                return null;
            }
        }

        public IEnumerator<Connection> GetEnumerator()
        {
            if (pointer <= connections.Count - 1)
                for (int i = 0; i < connections.Count; i++)
                {
                    pointer += 1;
                    yield return connections[i];
                }
            else
            {
                pointer = 0;
                yield break;
            }
                
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
