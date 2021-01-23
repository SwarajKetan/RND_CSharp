using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgramRunner
{
    namespace Kejri
    {
        class Test
        {
            public int _id = 0;// field

            private int backing_id;
            public int Id {
                get { return backing_id; }
                set { backing_id = value + 2; }}

            void Th()
            {
                Task task = Task.Factory.StartNew(NoRet);

                // 1 - main
                // background thread
            }

            // .Net framework : Action, Func, Predicate
            void Do(Action act)
            {
                act.Invoke();
            }

            void Do1(Func<int> act)
            {

            }

            void Do2(Predicate<bool> act)
            {

            }


            void NoRet()
            {
            }

            void NoRet2()
            {
            }

            void Dirver()
            {
                Test t = new Test();

                t.Id = 5;

                int get = t.Id;

                Do(NoRet2);
            }
        }
    }
}
