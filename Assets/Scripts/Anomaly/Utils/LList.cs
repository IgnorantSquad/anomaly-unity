using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Utils
{
    public class LList<_Typ>
    {
        public _Typ data;
        public LList<_Typ> next = null;
        public bool isHead = false;

        public bool IsNull => ReferenceEquals(data, null);

        public static LList<_Typ> Create(_Typ initData = default(_Typ))
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

        public void Foreach(System.Action<_Typ> function)
        {
            var search = this;
            while (search.next != null)
            {
                function.Invoke(search.data);
                search = search.next;
            }
        }
    }
}
