using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raupjc_hw1
{
    class IntegerList : IIntegerlist
    {
        private int[] _internalStorage;
        private int _indexOfLastElement;

        public IntegerList()
        {
            _internalStorage = new int[4];
            _indexOfLastElement = -1;
        }

        public IntegerList(int initialSize)
        {
            if (initialSize < 0)
            {
                Console.WriteLine("Invalid list size");
            }
            else
            {
                _internalStorage = new int[initialSize];
                _indexOfLastElement = -1;
            }
        }

        public void Add(int item)
        {
            if (Count == _internalStorage.Length)
            {
                int[] newStorage = new int[_internalStorage.Length * 2];
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    newStorage[i] = _internalStorage[i];
                }
                _indexOfLastElement++;
                newStorage[_internalStorage.Length] = item;
                _internalStorage = newStorage;
            }
            else
            {
                _indexOfLastElement++;
                _internalStorage[_indexOfLastElement] = item;
            }
        }

        public bool Remove(int item)
        {
            for (int i = 0; i < _indexOfLastElement + 1; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > _indexOfLastElement)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = index; i < _indexOfLastElement; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }

                _indexOfLastElement--;
                return true;
            }
        }

        public int GetElement(int index)
        {
            if (index < 0 || index > _indexOfLastElement)
            {
                throw  new IndexOutOfRangeException();
            }
            else
            {
                return _internalStorage[index];
            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i <= _indexOfLastElement; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }

        public int Count
        {
            get { return _indexOfLastElement + 1; }
        }
        public void Clear()
        {
            _internalStorage = new int[_internalStorage.Length];
            _indexOfLastElement = - 1;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i <= _indexOfLastElement; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
