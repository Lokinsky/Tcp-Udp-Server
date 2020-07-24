using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using udp_server.Models;

namespace udp_server.DataStructures
{
    class Messages : IEnumerable<Message>
    {
        int pointer = 0;
        private List<Message> messages;
        private static Messages instance = null;
        private static readonly object padlock = new object();
        public int Count { get; set; }
        public Messages()
        {
            messages = new List<Message>();
        }
        private static Messages Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Messages();
                    }
                    return instance;
                }
            }
        }

        public void Add(Message message)
        {
            if (message != null)
            {
                messages.Add(message);
                Count = messages.Count;
            }
            else
            {
                Console.WriteLine("Error while putting channel in the list");
            }
        }

        public void Remove(int index)
        {
            if (index <= messages.Count - 1)
            {
                messages.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Error while removing at index: " + index);
            }
        }
        public void Remove(Message message)
        {
            if (message != null)
            {
                if (messages.Exists(e => e.User.Login == message.User.Login))
                {
                    messages.Remove(message);
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
        public Message Get(int index)
        {
            if (index <= messages.Count - 1)
            {
                return messages[index];
            }
            else
            {
                Console.WriteLine("Error while removing at index: " + index);
                return null;
            }
        }

        public IEnumerator<Message> GetEnumerator()
        {
            if (pointer <= messages.Count - 1)
                for (int i = 0; i < messages.Count; i++)
                {
                    pointer += 1;
                    yield return messages[i];
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
