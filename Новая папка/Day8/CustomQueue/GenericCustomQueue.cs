using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GenericCustomQueue
{
    public class GenericCustomQueue<T> : IEnumerable<T>
    {
        private class Element
        {
            public T value;
            public Element next;
            public Element previous;
            public Element(T value)
            {
                this.value = value;
            }
            public Element() {}
        }
        private Element start;
        private Element end;
        public int Count { get; private set; }
        public GenericCustomQueue() { }
        public void Enqueue(T value)
        {
            Element temp = new Element(value);
            if (Count > 0)
            {
                end.next = temp;
                temp.previous = end;
                end = temp;
                Count++;
            }
            else
            {
                start = temp;
                end = start;
                Count++;
            }
        }
        public T Dequeue()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            Count--;
            T value = start.value;
            start = start.next;
            return value;
        }
        public T Peek()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return start.value;
        }




        public IEnumerator<T> GetEnumerator()
        {
            return new CustomIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class CustomIterator : IEnumerator<T>
        {
            private readonly GenericCustomQueue<T> queue;
            private Element currentElement;
            public CustomIterator(GenericCustomQueue<T> queue)
            {
                currentElement = new Element();
                this.currentElement.next = queue.start;
                this.queue = queue;
            }
            public T Current
            {
                get
                {
                    if (currentElement == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return currentElement.value;
                }
            }
            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }
            public void Reset()
            {
                currentElement.next = queue.start;
                currentElement.previous = null;
                currentElement.value = default(T);
                //throw new NotSupportedException();
            }

            public bool MoveNext()
            {
                if (currentElement.next != null)
                {
                    currentElement = currentElement.next;
                    return true;
                }
                else return false;
            }

            public void Dispose() { }
        }     



    }
}
