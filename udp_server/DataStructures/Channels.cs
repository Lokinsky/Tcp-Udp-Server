using System;
using System.Collections.Generic;
using System.Text;
using udp_server.Models;

namespace udp_server.DataStructures
{
    class Channels
    {
        private List<Channel> channels;
        private static Channels instance = null;
        private static readonly object padlock = new object();
        public int Count { get; set; }
        private Channels()
        {
            channels = new List<Channel>();
        }
        public static Channels Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Channels();
                    }
                    return instance;
                }
            }
        }

        public void Add(Channel channel)
        {
            if (channel != null)
            {
                channels.Add(channel);
                Count = channels.Count;
            }
            else
            {
                Console.WriteLine("Error while putting channel in the list");
            }
        }

        public void Remove(int index)
        {
            if (index <= channels.Count - 1)
            {
                channels.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Error while removing at index: " + index);
            }
        }
        public void Remove(Channel channel)
        {
            if (channel != null)
            {
                if (channels.Exists(e => e.Name == channel.Name))
                {
                    channels.Remove(channel);
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
        public Channel Get(int index)
        {
            if (index <= channels.Count - 1)
            {
                return channels[index];
            }
            else
            {
                Console.WriteLine("Error while removing at index: " + index);
                return null;
            }
        }
    }
}
