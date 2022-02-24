using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Utils
{
    public class LList<_Typ> where _Typ : class
    {
        public _Typ data;
        public LList<_Typ> next = null;
        public bool isHead = false;

        public bool IsNull => ReferenceEquals(data, null);

        public static LList<_Typ> Create()
        {
            LList<_Typ> head = new LList<_Typ>();
            head.isHead = true;
            head.data = null;
            return head;
        }

        public static LList<_Typ> Create(_Typ initData)
        {
            LList<_Typ> head = new LList<_Typ>();
            head.isHead = true;
            head.data = initData;
            return head;
        }

        public void Add(LList<_Typ> other)
        {
            if (other == null) return;
            var last = this;
            while (last.next != null) last = last.next;
            last.next = other;
            other.isHead = false;
        }

        public void Add(_Typ other)
        {
            if (isHead && IsNull)
            {
                this.data = other;
                return;
            }

            LList<_Typ> node = new LList<_Typ>();
            node.data = other;
            Add(node);
        }

        public static void Remove(LList<_Typ> head, LList<_Typ> node)
        {
            if (head == null || node == null) return;

            LList<_Typ> iter = head.next;

            if (ReferenceEquals(head, node))
            {
                head.next.isHead = true;
                head = null;
                return;
            }

            while (iter != null)
            {
                if (ReferenceEquals(iter.next, node))
                {
                    iter.next = node.next;
                    node = null; node.next = null;
                    break;
                }
                iter = iter.next;
            }
        }

        public void Clear()
        {
            // var search = this;
            // while (this.next != null)
            // {
            //     while (search.next.next != null)
            //     {
            //         search = search.next;
            //     }
            //     search.next.data = null;
            //     search.next = null;
            // }

            // this.data = null;
        }

        public void Foreach(System.Action<_Typ> function)
        {
            var search = this;
            while (search != null)
            {
                if (!search.IsNull) function.Invoke(search.data);
                search = search.next;
            }
        }
    }
}
