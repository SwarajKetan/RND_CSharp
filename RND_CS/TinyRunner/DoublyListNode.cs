namespace TinyRunner
{
    public class DoublyListNode
    {
        public int val;
        public DoublyListNode next;
        public DoublyListNode prev;
        public DoublyListNode(int val = 0, DoublyListNode next = null, DoublyListNode prev = null)
        {
            this.val = val;
            this.next = next;
            this.prev = prev;
        }
    }
}
