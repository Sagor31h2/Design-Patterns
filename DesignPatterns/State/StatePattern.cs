using System;


namespace DesignPatterns.State
{
    // State Interface
    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
    }

    // NoQuarterState
    public class NoQuarterState : IState
    {
        private readonly GumballMachine _machine;

        public NoQuarterState(GumballMachine machine)
        {
            _machine = machine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You inserted a quarter.");
            _machine.SetState(_machine.HasQuarterState);
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You haven’t inserted a quarter.");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned, but there’s no quarter.");
        }

        public void Dispense()
        {
            Console.WriteLine("You need to pay first.");
        }
    }

    // HasQuarterState
    public class HasQuarterState : IState
    {
        private readonly GumballMachine _machine;

        public HasQuarterState(GumballMachine machine)
        {
            _machine = machine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can’t insert another quarter.");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Quarter returned.");
            _machine.SetState(_machine.NoQuarterState);
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned the crank...");
            _machine.SetState(_machine.SoldState);
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed.");
        }
    }

    // SoldState
    public class SoldState : IState
    {
        private readonly GumballMachine _machine;

        public SoldState(GumballMachine machine)
        {
            _machine = machine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Please wait, we’re already giving you a gumball.");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Sorry, you already turned the crank.");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Turning twice doesn’t get you another gumball!");
        }

        public void Dispense()
        {
            _machine.ReleaseBall();
            if (_machine.Count > 0)
            {
                _machine.SetState(_machine.NoQuarterState);
            }
            else
            {
                Console.WriteLine("Oops, out of gumballs!");
                _machine.SetState(_machine.SoldOutState);
            }
        }
    }

    // SoldOutState
    public class SoldOutState : IState
    {
        private readonly GumballMachine _machine;

        public SoldOutState(GumballMachine machine)
        {
            _machine = machine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Machine is sold out.");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You can’t eject, you haven’t inserted a quarter yet.");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned, but there are no gumballs.");
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed.");
        }
    }

    // Context
    public class GumballMachine
    {
        public IState SoldOutState { get; }
        public IState NoQuarterState { get; }
        public IState HasQuarterState { get; }
        public IState SoldState { get; }

        private IState _state;
        public int Count { get; private set; }

        public GumballMachine(int count)
        {
            SoldOutState = new SoldOutState(this);
            NoQuarterState = new NoQuarterState(this);
            HasQuarterState = new HasQuarterState(this);
            SoldState = new SoldState(this);

            Count = count;
            _state = count > 0 ? NoQuarterState : SoldOutState;
        }

        public void InsertQuarter() => _state.InsertQuarter();
        public void EjectQuarter() => _state.EjectQuarter();
        public void TurnCrank()
        {
            _state.TurnCrank();
            _state.Dispense();
        }

        public void SetState(IState state) => _state = state;

        public void ReleaseBall()
        {
            if (Count > 0)
            {
                Console.WriteLine("A gumball comes rolling out...");
                Count--;
            }
        }

        public void Refill(int count)
        {
            Count += count;
            Console.WriteLine($"Machine refilled. New count: {Count}");
            _state = NoQuarterState;
        }

        public override string ToString()
        {
            return $"\nInventory: {Count} gumball(s)\nMachine is currently in {_state.GetType().Name}\n";
        }
    }

    // Test Program
    class StatePattern
    {
        public void Test()
        {
            GumballMachine gumballMachine = new GumballMachine(3);

            Console.WriteLine(gumballMachine);

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();

            Console.WriteLine(gumballMachine);

            gumballMachine.InsertQuarter();
            gumballMachine.EjectQuarter();
            gumballMachine.TurnCrank();

            Console.WriteLine(gumballMachine);

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();

            Console.WriteLine(gumballMachine);
        }
    }
}

