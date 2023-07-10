using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static HW6_module3.MessageBox;

namespace HW6_module3
{
    internal class MessageBox
    {
        public MessageBox()
        {
            StateChanged = GetMess;
        }

        private delegate void EventHandler(State status);
        private event EventHandler StateChanged;

        public enum State
        {
            Ok,
            Cancel
        }

        public async void Open()
        {
            Console.WriteLine("Window opened");
            await Task.Run(() =>
            {
                Task.Delay(3000);
            });
            Console.WriteLine("Window closed");
            State state = RandomSate();
            StateChanged(state);
        }

        public void GetMess(State status)
        {
            if (status == State.Ok)
            {
                Console.WriteLine("The operation was confirmed!!");
            }
            else
            {
                Console.WriteLine("The operation was canceled!!");
            }
        }

        public State RandomSate()
        {
            Random random = new Random();
            var x = random.Next(1, 3);
            if (x == 1)
            {
                return State.Ok;
            }

            return State.Cancel;
        }
    }
}