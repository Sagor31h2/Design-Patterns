using System;

namespace DesignPatterns.CommandPattern;


// Command Interface
public interface ICommand
{
    void Execute();
    void Undo();
}

// Receiver - Light
public class Light
{
    public void On() => Console.WriteLine("The light is ON.");
    public void Off() => Console.WriteLine("The light is OFF.");
}

// Receiver - Fan
public class Fan
{
    public void High() => Console.WriteLine("The fan is set to HIGH.");
    public void Off() => Console.WriteLine("The fan is OFF.");
}

// Concrete Command - Light On
public class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light) => _light = light;

    public void Execute() => _light.On();
    public void Undo() => _light.Off();
}

// Concrete Command - Light Off
public class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light) => _light = light;

    public void Execute() => _light.Off();
    public void Undo() => _light.On();
}

// Concrete Command - Fan High
public class FanHighCommand : ICommand
{
    private readonly Fan _fan;

    public FanHighCommand(Fan fan) => _fan = fan;

    public void Execute() => _fan.High();
    public void Undo() => _fan.Off();
}

// Concrete Command - Fan Off
public class FanOffCommand : ICommand
{
    private readonly Fan _fan;

    public FanOffCommand(Fan fan) => _fan = fan;

    public void Execute() => _fan.Off();
    public void Undo() => _fan.High();
}

// Invoker - Remote Control
public class RemoteControl
{
    private ICommand _slot;
    private ICommand _lastCommand;

    public void SetCommand(ICommand command) => _slot = command;

    public void PressButton()
    {
        _slot.Execute();
        _lastCommand = _slot;
    }

    public void PressUndo()
    {
        if (_lastCommand != null)
        {
            _lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }
}

// Client
public class CommandPatternConsole
{
    public void Test()
    {
        // Receivers
        Light livingRoomLight = new Light();
        Fan ceilingFan = new Fan();

        // Commands
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);
        ICommand fanHigh = new FanHighCommand(ceilingFan);
        ICommand fanOff = new FanOffCommand(ceilingFan);

        // Invoker
        RemoteControl remote = new RemoteControl();

        // Using Light Commands
        remote.SetCommand(lightOn);
        remote.PressButton();
        remote.PressUndo();

        remote.SetCommand(lightOff);
        remote.PressButton();
        remote.PressUndo();

        // Using Fan Commands
        remote.SetCommand(fanHigh);
        remote.PressButton();
        remote.PressUndo();

        remote.SetCommand(fanOff);
        remote.PressButton();
        remote.PressUndo();
    }
}


